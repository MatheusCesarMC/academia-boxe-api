using SistemaAcademiaBoxe.Models;

namespace SistemaAcademiaBoxe.Data;

public class AlunoRepository
{
    private readonly List<Aluno> _alunos = new();

    public List<Aluno> ListarTodos()
    {
        return _alunos;
    }

    public Aluno? BuscarPorId(string id)
    {
        return _alunos.FirstOrDefault(a => a.Id == id);
    }

    public void Adicionar(Aluno aluno)
    {
        _alunos.Add(aluno);
    }

    public bool Atualizar(string id, Aluno alunoAtualizado)
    {
        var aluno = BuscarPorId(id);

        if (aluno == null)
        {
            return false;
        }

        aluno.Nome = alunoAtualizado.Nome;
        aluno.Email = alunoAtualizado.Email;
        aluno.Telefone = alunoAtualizado.Telefone;

        return true;
    }

    public bool Remover(string id)
    {
        var aluno = BuscarPorId(id);

        if (aluno == null)
        {
            return false;
        }

        _alunos.Remove(aluno);
        return true;
    }
}