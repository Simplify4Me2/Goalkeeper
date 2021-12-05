using GoalKeeper.Common.Application.IO.Services;
using GoalKeeper.DataCollector.App.Configuration;
using GoalKeeper.DataCollector.App.Data;
using GoalKeeper.DataCollector.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IocConfig.ConfigureExternalServices(builder.Services, builder.Configuration);
var statsConfiguration = new ServiceConfiguration();
builder.Configuration.Bind("StatsAPI", statsConfiguration);
//builder.Services.AddScoped<IMatchService, GoalKeeper.Stats.Application.IO.Services.MatchService>(provider => new GoalKeeper.Stats.Application.IO.Services.MatchService(statsConfiguration, provider.GetService<IHttpClientFactory>()));
builder.Services.AddHttpClient<IMatchService, GoalKeeper.Stats.Application.IO.Services.MatchService>(client => { client.BaseAddress = new Uri(statsConfiguration.BaseUrl); });

var dataCollectorConfiguration = new ServiceConfiguration();
builder.Configuration.Bind("DataCollectorAPI", dataCollectorConfiguration);
//builder.Services.AddScoped<IMatchWebScraperService, MatchWebScraperService>(provider => new MatchWebScraperService(dataCollectorConfiguration, provider.GetService<IHttpClientFactory>()));
builder.Services.AddHttpClient<IMatchWebScraperService, MatchWebScraperService>(client => { client.BaseAddress = new Uri(dataCollectorConfiguration.BaseUrl); });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<GoalKeeper.DataCollector.App.Data.MatchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
