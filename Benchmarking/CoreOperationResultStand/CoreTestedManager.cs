using ATI.Services.Common.Behaviors;
using Benchmarking.Entities;

namespace Benchmarking.CoreOperationResultStand;

public class CoreTestedManager
{
    private readonly CoreTestedClient _coreTestedClient;

    public CoreTestedManager(CoreTestedClient coreTestedClient)
    {
        _coreTestedClient = coreTestedClient;
    }

    public OperationResult<CounterDto> SendSms()
    {
        var checkOperation = _coreTestedClient.GetSmsAccess();
        if (!checkOperation.Success)
            return new OperationResult<CounterDto>();

        return _coreTestedClient.DoWork();
    }
    
    public OperationResult<CounterView> GetCounter()
    {
        var counterOperation =  _coreTestedClient.DoWork();
        if (!counterOperation.Success)
            return new OperationResult<CounterView>();
        
        return new(new CounterView
        {
            Count = counterOperation.Value.Count
        });
    }
}