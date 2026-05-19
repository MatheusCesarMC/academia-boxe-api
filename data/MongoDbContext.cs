using MongoDB.Driver;
using SistemaAcademiaBoxe.Models;
using SistemaAcademiaBoxe.Settings;
using Microsoft.Extensions.Options;

namespace SistemaAcademiaBoxe.Data;

// Classe responsável por configurar a conexão com o MongoDB
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

// Construtor que recebe as configurações do MongoDB (connection string, nome do banco)
    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
    }

// retorna a coleção de alunos
    public IMongoCollection<Aluno> Alunos =>
        _database.GetCollection<Aluno>("alunos");

// retorna a coleção de professores
    public IMongoCollection<Professor> Professores =>
    _database.GetCollection<Professor>("professores");
}