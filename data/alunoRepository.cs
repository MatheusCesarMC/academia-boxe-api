using MongoDB.Driver;
using SistemaAcademiaBoxe.Models;

namespace SistemaAcademiaBoxe.Data;

// Classe responsável por acessar e manipular os dados de Aluno no MongoDB
public class AlunoRepository
{
    private readonly IMongoCollection<Aluno> _alunos;

    public AlunoRepository(MongoDbContext context)
    {
        _alunos = context.Alunos;
    }

    public async Task<List<Aluno>> GetAll()
    {
        return await _alunos.Find(_ => true).ToListAsync();
    }

    public async Task<Aluno?> GetById(Guid id)
    {
        return await _alunos.Find(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task Add(Aluno aluno)
    {
        await _alunos.InsertOneAsync(aluno);
    }

    public async Task Update(Guid id, Aluno aluno)
    {
        await _alunos.ReplaceOneAsync(a => a.Id == id, aluno);
    }

    public async Task Delete(Guid id)
    {
        await _alunos.DeleteOneAsync(a => a.Id == id);
    }

    public async Task<Aluno?> GetByDadosDuplicados(string nome, string email, string telefone)
    {
        return await _alunos
            .Find(a => a.Email == email || a.Telefone == telefone || a.Nome == nome )
            .FirstOrDefaultAsync();
    }
}