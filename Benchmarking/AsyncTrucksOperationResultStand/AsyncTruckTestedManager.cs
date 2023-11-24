using Benchmarking.AsyncTrucksOperationResultStand.Entities;
using Benchmarking.Entities;

namespace Benchmarking.AsyncTrucksOperationResultStand;

public class AsyncTruckTestedManager
{
    private readonly AsyncTruckTestedClient _truckTestedClient;

    public AsyncTruckTestedManager(AsyncTruckTestedClient truckTestedClient)
    {
        _truckTestedClient = truckTestedClient;
    }

    public async Task<AsyncTruckOperationResult<CounterDto>> SendSmsAsync()
    {
        var checkOperation = await _truckTestedClient.GetSmsAccessAsync();
        if (checkOperation.IsNotSuccess)
            return checkOperation.FlowError<CounterDto>();

        return await _truckTestedClient.DoWorkAsync();
    }
    
    public async Task<CounterView> GetCounterAsync()
    {
        var counter = await _truckTestedClient.DoWorkAsync();
   
        return new CounterView
        {
            Count = counter.Count
        };
    }
}