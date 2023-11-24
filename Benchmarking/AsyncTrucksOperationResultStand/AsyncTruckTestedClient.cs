using Benchmarking.AsyncTrucksOperationResultStand.Entities;
using Benchmarking.Entities;

namespace Benchmarking.AsyncTrucksOperationResultStand;

public class AsyncTruckTestedClient
{
    private readonly Random _random = new();
    private readonly AsyncTruckBadRequestError _error = new();

    public Task<AsyncTruckOperationResult<AccessDto>> GetSmsAccessAsync()
    {
        if (_random.Next(0, 10) == 0)
        {
            return Task.FromResult(AsyncTruckOperationResult<AccessDto>.Failed(_error));
        }

        return Task.FromResult(AsyncTruckOperationResult<AccessDto>.Success(new AccessDto()));
    }

    public Task<CounterDto> DoWorkAsync()
    {
        return Task.FromResult(new CounterDto
        {
            Count = _random.Next(0, 10)
        });
    }
}