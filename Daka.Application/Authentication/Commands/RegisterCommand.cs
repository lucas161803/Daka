using Daka.Application.Authentication.Common;
using MediatR;

namespace Daka.Application.Authentication.Commands;

public record RegisterCommand(string Name) : IRequest<RegisterResponse>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new RegisterResponse
        {
            Name = request.Name
        };

        return Task.FromResult(response);
    }
}