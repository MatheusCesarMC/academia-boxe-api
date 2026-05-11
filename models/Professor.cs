using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaAcademiaBoxe.Models;

public class Professor
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}