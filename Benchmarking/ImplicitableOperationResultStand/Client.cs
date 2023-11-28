using Benchmarking.Entities;
using Benchmarking.ImplicitableOperationResultStand.Entities;

namespace Benchmarking.ImplicitableOperationResultStand;

public class Client
{
    private readonly Random _random = new();
    private readonly BadRequestError _error = new();

    public Task<Operation<AccessDto>> GetSmsAccessAsync()
    {
        if (_random.Next(0, 10) == 0)
        {
            return Task.FromResult(new Operation<AccessDto>(_error));
        }

        return Task.FromResult(new Operation<AccessDto>(new AccessDto()));
    }

    public Task<CounterDto> DoWorkAsync()
    {
        return Task.FromResult(new CounterDto
        {
            Count = _random.Next(0, 10)
        });
    }
}