using Microsoft.AspNetCore.Mvc;
using SistemaAcademiaBoxe.Data;
using SistemaAcademiaBoxe.Models;

namespace SistemaAcademiaBoxe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly ProfessorRepository _repository;

    public ProfessoresController(ProfessorRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var professores = await _repository.GetAll();
        return Ok(professores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var professor = await _repository.GetById(id);

        if (professor == null)
            return NotFound();

        return Ok(professor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Professor professor)
    {
        await _repository.Add(professor);

        return CreatedAtAction(
            nameof(GetById),
            new { id = professor.Id },
            professor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Professor professor)
    {
        await _repository.Update(id, professor);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repository.Delete(id);

        return NoContent();
    }
}