using Daka.Application.Authentication.Common;
using MediatR;

namespace Daka.Application.Authentication.Commands;

public record LoginCommand(string Account, string Password) : IRequest<LoginResponse>;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginResponse = new LoginResponse
        {
            Token = "member-token"
        };

        return Task.FromResult(loginResponse);
    }
}