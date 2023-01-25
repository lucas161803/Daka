using Daka.Application.Leave.Common;
using Daka.Application.Persistence;
using MediatR;

namespace Daka.Application.Leave.Commands;

public record ApplyLeaveCommand(LeavePeriod LeavePeriod, int LeaveTypeId) : IRequest<ApplyLeaveResult>;

internal class ApplyLeaveCommandHandler : IRequestHandler<ApplyLeaveCommand, ApplyLeaveResult>
{
    private readonly IAccessMemberLeaveRepository _accessMemberLeaveRepository;

    public ApplyLeaveCommandHandler(IAccessMemberLeaveRepository accessMemberLeaveRepository)
    {
        _accessMemberLeaveRepository = accessMemberLeaveRepository;
    }

    public async Task<ApplyLeaveResult> Handle(ApplyLeaveCommand request, CancellationToken cancellationToken)
    {
        var applyMemberLeaveVm = await _accessMemberLeaveRepository.Add(new AddMemberLeaveModel());
        return new ApplyLeaveResult();
    }
}