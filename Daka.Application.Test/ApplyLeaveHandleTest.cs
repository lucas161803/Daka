using Daka.Application.Leave.Commands;
using Daka.Application.Leave.Common;
using Daka.Application.Persistence;

namespace Daka.Application.Test;

public class ApplyLeaveHandleTest
{
    private ApplyLeaveCommandHandler _handler = null!;
    private FakeAccessMemberLeaveRepository _repository = null!;

    [SetUp]
    public void SetUp()
    {
        _repository = new FakeAccessMemberLeaveRepository();
        _handler = new ApplyLeaveCommandHandler(_repository);
    }

    [Test]
    public async Task Apply_Should_AppendToMemberLeaveList()
    {
        const int leaveTypeId = 1;
        var actual = await _handler.Handle(new ApplyLeaveCommand(
            new LeavePeriod
            {
                Start = DateTime.Parse("2023/01/01"),
                End = DateTime.Parse("2023/01/02")
            }, leaveTypeId), new CancellationToken());

        Assert.That(_repository.Count(), Is.EqualTo(1));
    }
}

public class FakeAccessMemberLeaveRepository : IAccessMemberLeaveRepository
{
    private readonly List<AddMemberLeaveModel> _list;

    public FakeAccessMemberLeaveRepository()
    {
        _list = new List<AddMemberLeaveModel>();
    }

    public Task<ApplyMemberLeaveVm> Add(AddMemberLeaveModel model)
    {
        _list.Add(model);
        return Task.FromResult(new ApplyMemberLeaveVm());
    }

    public int Count()
    {
        return _list.Count;
    }
}