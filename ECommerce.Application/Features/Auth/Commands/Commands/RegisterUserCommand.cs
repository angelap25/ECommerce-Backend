using MediatR;

using ECommerce.Application.Features.Auth.DTOs;

namespace ECommerce.Application.Features.Auth.Commands;

public class RegisterUserCommand
    : IRequest<AuthResponseDto>
{
    public string Name { get; set; }
        = string.Empty;

    public string Email { get; set; }
        = string.Empty;

    public string Password { get; set; }
        = string.Empty;
}   