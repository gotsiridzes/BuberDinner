﻿using ErrorOr;
namespace BuberDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}