using Benchmarking.Entities;
using Benchmarking.TrucksOperationResultStand.Entities;

namespace Benchmarking.TrucksOperationResultStand;

public class TruckTestedClient
{
    private readonly Random _random = new();
    private readonly TruckBadRequestError _error = new();

    public TruckOperationResult<AccessDto> GetSmsAccess()
    {
        if (_random.Next(0, 10) == 0)
        {
            return TruckOperationResult<AccessDto>.Failed(_error);
        }

        return TruckOperationResult<AccessDto>.Success(new AccessDto());
    }

    public CounterDto DoWork()
    {
        return new CounterDto
        {
            Count = _random.Next(0, 10)
        };
    }
}