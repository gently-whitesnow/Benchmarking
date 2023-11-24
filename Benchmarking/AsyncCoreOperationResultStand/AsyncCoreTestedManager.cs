using ATI.Services.Common.Behaviors;
using Benchmarking.CoreOperationResultStand;
using Benchmarking.Entities;

namespace Benchmarking.AsyncCoreOperationResultStand;

public class AsyncCoreTestedManager
{
    private readonly AsyncCoreTestedClient _coreTestedClient;

    public AsyncCoreTestedManager(AsyncCoreTestedClient coreTestedClient)
    {
        _coreTestedClient = coreTestedClient;
    }

    public async Task<OperationResult<CounterDto>> SendSmsAsync()
    {
        var checkOperation = await _coreTestedClient.GetSmsAccessAsync();
        if (!checkOperation.Success)
            return new OperationResult<CounterDto>();

        return await _coreTestedClient.DoWorkAsync();
    }
    
    public async Task<OperationResult<CounterView>> GetCounterAsync()
    {
        var counterOperation =  await _coreTestedClient.DoWorkAsync();
        if (!counterOperation.Success)
            return new OperationResult<CounterView>();
        
        return new(new CounterView
        {
            Count = counterOperation.Value.Count
        });
    }
}