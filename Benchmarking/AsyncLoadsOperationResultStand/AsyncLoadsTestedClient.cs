using Benchmarking.AsyncLoadsOperationResultStand.Entities;
using Benchmarking.Entities;

namespace Benchmarking.AsyncLoadsOperationResultStand;

public class AsyncLoadsTestedClient
{
    private readonly Random _random = new();
    private readonly AsyncLoadsBadRequestError _error = new();

    public  Task<AsyncLoadsOperationResult<AccessDto>> GetSmsAccessAsync()
    {
        if (_random.Next(0, 10) == 0)
        {
            return Task.FromResult(AsyncLoadsOperationResult<AccessDto>.Failed(_error));
        }

        return Task.FromResult(AsyncLoadsOperationResult<AccessDto>.Success(new AccessDto()));
    }

    public Task<AsyncLoadsOperationResult<CounterDto>> DoWork()
    {
        return Task.FromResult(AsyncLoadsOperationResult<CounterDto>.Success(new CounterDto
        {
            Count = _random.Next(0, 10)
        }));
    }
}