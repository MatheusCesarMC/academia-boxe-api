using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaAcademiaBoxe.Models;

public class Aluno
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string ProfessorResponsavel { get; set; } = string.Empty;
}