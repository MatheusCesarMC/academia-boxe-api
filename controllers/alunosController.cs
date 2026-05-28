using Microsoft.AspNetCore.Mvc;
using SistemaAcademiaBoxe.Data;
using SistemaAcademiaBoxe.Models;

namespace SistemaAcademiaBoxe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly AlunoRepository _repository;

    public AlunosController(AlunoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var alunos = await _repository.GetAll();
        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var aluno = await _repository.GetById(id);

        if (aluno == null)
            return NotFound();

        return Ok(aluno);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Aluno aluno)
    {
        var alunoExistente = await _repository.GetByNomeEmailOrTelefone(
            aluno.Nome,
            aluno.Email,
            aluno.Telefone
        );

        if (alunoExistente != null)
        {
            return BadRequest("Ja existe um aluno cadastrado com este nome, email ou telefone.");
        }

        await _repository.Add(aluno);
        return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
    }

   [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Aluno aluno)
        {
    var alunoExistente = await _repository.GetById(id);

    if (alunoExistente == null)
        return NotFound();// 404 

    aluno.Id = id;

    await _repository.Update(id, aluno);

    return NoContent();//204 (No Content) deu certo, mas sem nada para devolver
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var aluno = await _repository.GetById(id);

        if (aluno == null)
            return NotFound();// 404

        await _repository.Delete(id);

        return NoContent();//204 (No Content) deu certo, mas sem nada para devolver
    }
}