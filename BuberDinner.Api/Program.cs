using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/auth/register", (
        IAuthenticationService authenticationService,
        [FromBody] RegisterRequest request) =>
    {
        var authResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Task.FromResult(Results.Ok(response));
    })
    .WithName("Register")
    .WithOpenApi();

app.MapPost("/auth/login", (IAuthenticationService authenticationService, [FromBody] LoginRequest request) =>
    {
        var loginResult = authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            loginResult.Id,
            loginResult.FirstName,
            loginResult.LastName,
            loginResult.Email,
            loginResult.Token);

        return Task.FromResult(Results.Ok(response));
    })
    .WithName("Login")
    .WithOpenApi();

app.Run();