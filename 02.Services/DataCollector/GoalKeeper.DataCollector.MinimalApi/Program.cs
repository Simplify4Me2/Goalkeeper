using GoalKeeper.Common.Application.IO;
using GoalKeeper.DataCollector.Application;
using GoalKeeper.DataCollector.Application.IO;
using GoalKeeper.DataCollector.Application.IO.DTOs;
using GoalKeeper.DataCollector.Application.IO.Queries;
using GoalKeeper.DataCollector.Application.Ports;
using GoalKeeper.DataCollector.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Program));
builder.Services.AddTransient<IMatchRepository, SQLRepository>();
//builder.Services.AddDbContext<MatchDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(""));
builder.Services.AddDbContext<MatchDbContext>(options => options.UseSqlServer(@"Data Source=.;Initial Catalog=DataCollectorDB;User Id=sqladmin;Password=txCnJqOynDfQaEbHpgNJ;Application Name=DataCollector.Database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (IMediator mediator) =>
{
    mediator.Send(new MatchdayQuery(1));
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/match/{matchday}", async (int matchday, IMediator mediator) =>
{
    var query = new MatchdayQuery(matchday);
    return new Result<MatchdayDTO>(await mediator.Send(query));
}).WithName("GetMatches");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}