using Microsoft.AspNetCore.Hosting.Server;

const string server = "https://localhost:7296/";
const string callback = "https://localhost:7129/wh/item/new";
const string topic = "item.new";

var client = new HttpClient();

Console.WriteLine($"Subscribing to topic {topic} with callback {callback}");
await client.PostAsJsonAsync(server + "/subscribe", new { topic, callback });

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

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
app.MapPost("/wh/item/new", (object payload, ILogger<Program> logger) =>
{
    logger.LogInformation("Received payload: {payload}", payload);
});
app.Run();
