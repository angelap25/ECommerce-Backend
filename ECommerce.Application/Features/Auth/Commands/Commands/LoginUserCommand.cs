using MediatR;

using ECommerce.Application.Features.Auth.DTOs;

namespace ECommerce.Application.Features.Auth.Commands;

public class LoginUserCommand
    : IRequest<AuthResponseDto>
{
    public string Email { get; set; }
        = string.Empty;

    public string Password { get; set; }
        = string.Empty;
}