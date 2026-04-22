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
    public ActionResult<List<Aluno>> Get()
    {
        return Ok(_repository.ListarTodos());
    }

    [HttpGet("{id}")]
    public ActionResult<Aluno> GetById(string id)
    {
        var aluno = _repository.BuscarPorId(id);

        if (aluno == null)
        {
            return NotFound();
        }

        return Ok(aluno);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Aluno aluno)
    {
        _repository.Adicionar(aluno);
        return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
    }

    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] Aluno aluno)
    {
        var atualizado = _repository.Atualizar(id, aluno);

        if (!atualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var removido = _repository.Remover(id);

        if (!removido)
        {
            return NotFound();
        }

        return NoContent();
    }
}