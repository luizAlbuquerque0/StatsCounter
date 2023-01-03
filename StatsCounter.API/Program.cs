using MediatR;
using Microsoft.EntityFrameworkCore;
using StatsCounter.Application.Commands.CreatePlayer;
using StatsCounter.Core.Repositories;
using StatsCounter.Infrastructure.Persistence;
using StatsCounter.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conectionString = builder.Configuration.GetConnectionString("StatsCounterCs");
builder.Services.AddDbContext<StatsCounterDbContext>(options => options.UseSqlServer(conectionString));
builder.Services.AddMediatR(typeof(CreatePlayerCommand));

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();

builder.Services.AddControllers();
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
