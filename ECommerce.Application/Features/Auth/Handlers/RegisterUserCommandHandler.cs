using MediatR;

using ECommerce.Application.Interfaces;

using ECommerce.Application.Features.Auth.Commands;
using ECommerce.Application.Features.Auth.DTOs;

using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Auth.Handlers;

public class RegisterUserCommandHandler
    : IRequestHandler<
        RegisterUserCommand,
        AuthResponseDto>
{
    private readonly IUserRepository
        _userRepository;

    private readonly IJwtService
        _jwtService;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;

        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto>
        Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken)
    {
        var hashedPassword =
            BCrypt.Net.BCrypt.HashPassword(
                request.Password);

        var user = new User(
            request.Name,
            request.Email,
            hashedPassword,
            "User");

        await _userRepository
            .AddAsync(user);

        var token =
            _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Username = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}