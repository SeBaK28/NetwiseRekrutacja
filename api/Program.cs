using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using api.Interfaces;
using api.Model;
using api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/saveToFile", async ([FromServices] IHttpClientFactory factory,
    IFileStorageService service, [FromServices] ILogger<Program> logger, 
    CancellationToken ct) =>
{
    var client = factory.CreateClient();
    try
    {    
        var response = await client.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact",ct);

        if(string.IsNullOrEmpty(response.Fact) || response.Length <= 0)
        {
            return Results.Problem(
                detail: "Variable cannot be null or empty",
                statusCode: StatusCodes.Status406NotAcceptable
            );
        }

        await service.SaveToFileAsync(response);

        return Results.Ok(new
            {
                Message=$"Dodano pomyślnie do pliku",
                StatusCodes.Status200OK
            }
        );
    }catch(TaskCanceledException ex)
    {
        logger.LogError("HTTP request timeout");
        return Results.Problem(
            detail: "HTTP request timeout" ,
            statusCode: StatusCodes.Status504GatewayTimeout
        );
    }catch(Exception ex)
    {
        logger.LogError($"ConnectionError: {ex.Message}");
        return Results.Problem(
            detail: $"ConnectionError: {ex.Message}", 
            statusCode: StatusCodes.Status502BadGateway
        );
    }
});


app.Run();
