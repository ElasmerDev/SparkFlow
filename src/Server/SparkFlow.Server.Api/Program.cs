// -----------------------------------------------------------------------------
// File: Program.cs
// Path: ./src/Server/SparkFlow.Server.Api/Program.cs
// Summary:
//   Entry point for the SparkFlow server API.
//
// Responsibilities:
//   - Configure services
//   - Configure middleware pipeline
//   - Start the web application
// -----------------------------------------------------------------------------

using SparkFlow.Server.Api.Extensions;
using SparkFlow.Server.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
