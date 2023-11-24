using Benchmarking.Entities;
using Benchmarking.LoadsOperationResultStand.Entities;

namespace Benchmarking.LoadsOperationResultStand;

public class LoadsTestedManager
{
    private readonly LoadsTestedClient _loadsTestedClient;

    public LoadsTestedManager(LoadsTestedClient loadsTestedClient)
    {
        _loadsTestedClient = loadsTestedClient;
    }

    public LoadsOperationResult<CounterDto> SendSms()
    {
        var checkOperation = _loadsTestedClient.GetSmsAccessAsync();
        if (checkOperation.IsNotSuccess)
            return checkOperation.FlowError<CounterDto>();

        return _loadsTestedClient.DoWork();
    }
    
    public LoadsOperationResult<CounterView> GetCounter()
    {
        var counterOperation = _loadsTestedClient.DoWork();
        if (counterOperation.IsNotSuccess)
            return counterOperation.FlowError<CounterView>();
        
        return new CounterView
        {
            Count = counterOperation.Result.Count
        };
    }
}