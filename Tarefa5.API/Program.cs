using Microsoft.EntityFrameworkCore;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Data.Postgres.Repository;
using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Data.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Service.Services;
using Tarefa5.Application.Services;
using Tarefa5.Domain.Interfaces.Rest;
using Tarefa5.Data.Rest.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IAcademiaService, AcademiaService>();
builder.Services.AddScoped<IAparelhoService, AparelhoService>();
builder.Services.AddScoped<IAcademiaRepository, AcademiaRepository>();
builder.Services.AddScoped<IAparelhoRepository, AparelhoRepository>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
