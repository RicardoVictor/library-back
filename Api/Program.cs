using Library.Api;
using Library.Api.Middlewares;
using Library.Infra.IoC;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddSqlServerDatabase(configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddExceptionHandler(options =>
{
    options.ExceptionHandler = GlobalExceptionHandler.Handle;
    options.AllowStatusCode404Response = true;
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.MapControllers();

app.Run();
