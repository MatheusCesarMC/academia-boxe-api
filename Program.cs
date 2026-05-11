using SistemaAcademiaBoxe.Data;
using SistemaAcademiaBoxe.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AlunoRepository>();
builder.Services.AddSingleton<ProfessorRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<MongoDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();