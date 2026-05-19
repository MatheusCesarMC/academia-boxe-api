using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaAcademiaBoxe.Models;

public class Aluno
{
    [BsonId]// identificador único no MongoDB(chave primaria)
    [BsonRepresentation(BsonType.String)] // Armazena o Guid como string no banco

    // ID único gerado automaticamente para cada aluno
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string ProfessorResponsavel { get; set; } = string.Empty;
}