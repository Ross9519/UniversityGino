using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.DataAccess.Models;
using University.DataAccess.Repositories;

namespace University.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(SubjectRepository repo, IMapper mapper) : ControllerBase
    {
        private readonly SubjectRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAll()
            => Ok(_mapper.Map<IEnumerable<SubjectDto>>(await _repo.GetAllAsync()));

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetOneById(long id)
        {
            var subject = _mapper.Map<SubjectDto>(await _repo.GetByIdAsync(id));

            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> Post(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);

            await _repo.InsertAsync(subject);

            var subjectDtoCreated = _mapper.Map<SubjectDto>(subject);

            return CreatedAtAction("GetOneById", new { id = subject.Id }, subjectDtoCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, SubjectDto subjectDto)
        {
            if (id != subjectDto.Id)
                return BadRequest();

            var subject = await _repo.GetByIdAsync(id);

            if (subject is null)
                return NotFound();

            await _repo.UpdateAsync(_mapper.Map(subjectDto, subject));

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneById(long id)
        {
            var subject = await _repo.GetByIdAsync(id);

            if (subject == null)
                return NotFound();

            await _repo.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
