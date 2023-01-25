using Daka.Application.Leave.Common;

namespace Daka.Application.Persistence;

public interface IAccessMemberLeaveRepository
{
    Task<ApplyMemberLeaveVm> Add(AddMemberLeaveModel model);
}