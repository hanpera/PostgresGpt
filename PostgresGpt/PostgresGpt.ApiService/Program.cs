using Microsoft.EntityFrameworkCore;
using PostgresGpt.ApiService.Data;
using PostgresGpt.ApiService.Options;
using PostgresGpt.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ItemContext>(options =>
//        options.UseNpgsql(builder.Configuration.GetConnectionString("TestDB"), o => o.UseVector()));
builder.AddNpgsqlDbContext<ChatContext>("ChatDB", null,
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ChatDB"), o => o.UseVector()));
// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.Configure<SemanticKernel>(builder.Configuration.GetSection("SemanticKernel"));
builder.Services.Configure<Chat>(builder.Configuration.GetSection("Chat"));
builder.Services.AddScoped<IDBService, PostgresDBService>();
builder.Services.AddScoped<ISemanticKernelService, SemanticKernelService>();
builder.Services.AddScoped<ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
