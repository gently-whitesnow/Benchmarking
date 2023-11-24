using Benchmarking.AsyncLoadsOperationResultStand.Entities;
using Benchmarking.Entities;

namespace Benchmarking.AsyncLoadsOperationResultStand;

public class AsyncLoadsTestedManager
{
    private readonly AsyncLoadsTestedClient _loadsTestedClient;

    public AsyncLoadsTestedManager(AsyncLoadsTestedClient loadsTestedClient)
    {
        _loadsTestedClient = loadsTestedClient;
    }

    public async Task<AsyncLoadsOperationResult<CounterDto>> SendSms()
    {
        var checkOperation = await _loadsTestedClient.GetSmsAccessAsync();
        if (checkOperation.IsNotSuccess)
            return checkOperation.FlowError<CounterDto>();

        return await _loadsTestedClient.DoWork();
    }
    
    public async Task<AsyncLoadsOperationResult<CounterView>> GetCounter()
    {
        var counterOperation =await _loadsTestedClient.DoWork();
        if (counterOperation.IsNotSuccess)
            return counterOperation.FlowError<CounterView>();
        
        return new CounterView
        {
            Count = counterOperation.Result.Count
        };
    }
}