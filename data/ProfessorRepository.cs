using MongoDB.Driver;
using SistemaAcademiaBoxe.Models;

namespace SistemaAcademiaBoxe.Data;

// Classe responsável por acessar e manipular os dados de Professor no MongoDB
public class ProfessorRepository
{
    private readonly IMongoCollection<Professor> _professores;

    public ProfessorRepository(MongoDbContext context)
    {
        _professores = context.Professores;
    }

    public async Task<List<Professor>> GetAll()
    {
        return await _professores.Find(_ => true).ToListAsync();
    }

    public async Task<Professor?> GetById(Guid id)
    {
        return await _professores.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task Add(Professor professor)
    {
        await _professores.InsertOneAsync(professor);
    }

    public async Task Update(Guid id, Professor professor)
    {
        await _professores.ReplaceOneAsync(p => p.Id == id, professor);
    }

    public async Task Delete(Guid id)
    {
        await _professores.DeleteOneAsync(p => p.Id == id);
    }
}