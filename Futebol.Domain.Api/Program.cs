using Futebol.Domain.Handlers;
using Futebol.Domain.Infra.Contexts;
using Futebol.Domain.Infra.Repositories;
using Futebol.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Futebol.Domain.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITimeRepository, TimeRepository>();
builder.Services.AddTransient<TimeHandler, TimeHandler>();
builder.Services.AddScoped<ConsultarTimeHandler, ConsultarTimeHandler>();

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
