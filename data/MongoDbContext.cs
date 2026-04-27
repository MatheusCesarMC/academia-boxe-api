using MongoDB.Driver;
using SistemaAcademiaBoxe.Models;
using SistemaAcademiaBoxe.Settings;
using Microsoft.Extensions.Options;

namespace SistemaAcademiaBoxe.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Aluno> Alunos =>
        _database.GetCollection<Aluno>("alunos");
}