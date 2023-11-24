using ATI.Services.Common.Behaviors;
using Benchmarking.Entities;

namespace Benchmarking.AsyncCoreOperationResultStand;

public class AsyncCoreTestedClient
{
    private readonly Random _random = new();
    private readonly OperationError _error = new(ActionStatus.BadRequest, "");

    public Task<OperationResult<AccessDto>> GetSmsAccessAsync()
    {
        if (_random.Next(0, 10) == 0)
        {
            return Task.FromResult(new OperationResult<AccessDto>(_error));
        }

        return Task.FromResult(new OperationResult<AccessDto>(new AccessDto()));
    }

    public Task<OperationResult<CounterDto>> DoWorkAsync()
    {
        return Task.FromResult(new OperationResult<CounterDto>(new CounterDto
        {
            Count = _random.Next(0, 10)
        }));
    }
}