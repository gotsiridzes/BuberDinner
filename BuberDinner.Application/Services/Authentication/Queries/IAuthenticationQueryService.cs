﻿using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
}