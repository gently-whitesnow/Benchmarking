using Benchmarking.Entities;
using Benchmarking.ImplicitableOperationResultStand.Entities;

namespace Benchmarking.ImplicitableOperationResultStand;

public class Manager
{
    private readonly Client _client;

    public Manager(Client client)
    {
        _client = client;
    }

    public async Task<Operation<CounterDto>> SendSmsAsync()
    {
        var checkOperation = await _client.GetSmsAccessAsync();
        if (checkOperation.IsError)
            return checkOperation.Error;

        return await _client.DoWorkAsync();
    }
    
    public async Task<CounterView> GetCounterAsync()
    {
        var counter = await _client.DoWorkAsync();
        
        // delete
   
        return new CounterView
        {
            Count = counter.Count
        };
    }
}