using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.DataAccess.Models;
using University.DataAccess.Repositories;

namespace University.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController(ProfessorRepository repo, IMapper mapper) : ControllerBase
    {
        private readonly ProfessorRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetAll()
            => Ok(_mapper.Map<IEnumerable<ProfessorDto>>(await _repo.GetAllAsync()));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorDto>> GetOneById(long id)
        {
            var professor = _mapper.Map<ProfessorDto>(await _repo.GetByIdAsync(id));

            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessorDto>> Post(ProfessorDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);

            await _repo.InsertAsync(professor);

            var professorDtoCreated = _mapper.Map<ProfessorDto>(professor);

            return CreatedAtAction("GetOneById", new { id = professor.Id }, professorDtoCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ProfessorDto professorDto)
        {
            if (id != professorDto.Id)
                return BadRequest();

            var professor = await _repo.GetByIdAsync(id);

            if (professor is null)
                return NotFound();

            await _repo.UpdateAsync(_mapper.Map(professorDto, professor));

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneById(long id)
        {
            var professor = await _repo.GetByIdAsync(id);

            if (professor == null)
                return NotFound();

            await _repo.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
