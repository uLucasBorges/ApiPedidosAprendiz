using ApiPedidosAprendiz.Infra.Data;
using ApiPedidosAprendiz.Infra.Repositorios;
using ApiPedidosAprendiz.Infra.Repositorios.Interfaces;
using ApiPedidosAprendiz.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();
builder.Services.AddScoped<ICepService, CepRepository>();


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
