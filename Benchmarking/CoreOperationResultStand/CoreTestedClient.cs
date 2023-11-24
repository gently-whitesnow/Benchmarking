using ATI.Services.Common.Behaviors;
using Benchmarking.Entities;

namespace Benchmarking.CoreOperationResultStand;

public class CoreTestedClient
{
    private readonly Random _random = new();
    private readonly OperationError _error = new(ActionStatus.BadRequest, "");

    public OperationResult<AccessDto> GetSmsAccess()
    {
        if (_random.Next(0, 10) == 0)
        {
            return new OperationResult<AccessDto>(_error);
        }

        return new OperationResult<AccessDto>(new AccessDto());
    }

    public OperationResult<CounterDto> DoWork()
    {
        return new OperationResult<CounterDto>(new CounterDto
        {
            Count = _random.Next(0, 10)
        });
    }
}