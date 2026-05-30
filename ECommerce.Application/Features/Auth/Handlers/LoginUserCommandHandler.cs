using MediatR;

using ECommerce.Application.Interfaces;

using ECommerce.Application.Features.Auth.Commands;
using ECommerce.Application.Features.Auth.DTOs;

namespace ECommerce.Application.Features.Auth.Handlers;

public class LoginUserCommandHandler
    : IRequestHandler<
        LoginUserCommand,
        AuthResponseDto>
{
    private readonly IUserRepository
        _userRepository;

    private readonly IJwtService
        _jwtService;

    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;

        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto>
        Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
    {
        var user =
            await _userRepository
                .GetByEmailAsync(
                    request.Email);

        if (user is null)
        {
            throw new Exception(
                "Invalid credentials");
        }

        var validPassword =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!validPassword)
        {
            throw new Exception(
                "Invalid credentials");
        }

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