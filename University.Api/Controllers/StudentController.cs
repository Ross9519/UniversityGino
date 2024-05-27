using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.DataAccess.Models;
using University.DataAccess.Repositories;

namespace University.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentRepository repo, IMapper mapper) : ControllerBase
    {
        private readonly StudentRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await _repo.GetAllAsync();

            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(studentDtos); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetOneById(long id)
        {
            var student = _mapper.Map<StudentDto>(await _repo.GetByIdAsync(id));

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            await _repo.InsertAsync(student);

            var studentDtoCreated = _mapper.Map<StudentDto>(student);

            return CreatedAtAction("GetOneById", new { id = student.Id }, studentDtoCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
                return BadRequest();

            var student = await _repo.GetByIdAsync(id);

            if (student is null)
                return NotFound();

            await _repo.UpdateAsync(_mapper.Map(studentDto, student));

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneById(long id)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            await _repo.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
