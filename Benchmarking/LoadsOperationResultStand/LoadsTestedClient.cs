using Benchmarking.Entities;
using Benchmarking.LoadsOperationResultStand.Entities;

namespace Benchmarking.LoadsOperationResultStand;

public class LoadsTestedClient
{
    private readonly Random _random = new();
    private readonly LoadsBadRequestError _error = new();

    public LoadsOperationResult<AccessDto> GetSmsAccessAsync()
    {
        if (_random.Next(0, 10) == 0)
        {
            return LoadsOperationResult<AccessDto>.Failed(_error);
        }

        return LoadsOperationResult<AccessDto>.Success(new AccessDto());
    }

    public LoadsOperationResult<CounterDto> DoWork()
    {
        return LoadsOperationResult<CounterDto>.Success(new CounterDto
        {
            Count = _random.Next(0, 10)
        });
    }
}