using Futebol.Domain.Handlers;
using Futebol.Domain.Infra.Contexts;
using Futebol.Domain.Infra.Repositories;
using Futebol.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Futebol.Domain.Api;
using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.ValidationBehavior;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => 
{   
    options.Filters.Add<NotificationFilter>();
});

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

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
