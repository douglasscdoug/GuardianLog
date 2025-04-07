using System.Text.Json.Serialization;
using GuardianLog.Application;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Helpers;
using GuardianLog.Repo;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(GuardianLogProfile));

builder.Services.AddScoped<IGeralRepository, GeralRepository>();
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<ICepRepository, CepRepository>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
builder.Services.AddScoped<ICorService, CorService>();
builder.Services.AddScoped<ICorRepository, CorRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IMarcaVeiculoService, MarcaVeiculoService>();
builder.Services.AddScoped<IMarcaVeiculoRepository, MarcaVeiculoRepository>();
builder.Services.AddScoped<IModeloVeiculoService, ModeloVeiculoService>();
builder.Services.AddScoped<IModeloVeiculoRepository, ModeloVeiculoRepository>();
builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<ITecnologiaService, TecnologiaService>();
builder.Services.AddScoped<ITecnologiaRepository, TecnologiaRepository>();
builder.Services.AddScoped<ITipoCarretaService, TipoCarretaService>();
builder.Services.AddScoped<ITipoCarretaRepository, TipoCarretaRepository>();
builder.Services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();
builder.Services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.MaxDepth = 64;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
