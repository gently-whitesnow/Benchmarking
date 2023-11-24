using Benchmarking.Entities;
using Benchmarking.TrucksOperationResult.Entities;
using Benchmarking.TrucksOperationResultStand.Entities;

namespace Benchmarking.TrucksOperationResultStand;

public class TruckTestedManager
{
    private readonly TruckTestedClient _truckTestedClient;

    public TruckTestedManager(TruckTestedClient truckTestedClient)
    {
        _truckTestedClient = truckTestedClient;
    }

    public TruckOperationResult<CounterDto> SendSms()
    {
        var checkOperation = _truckTestedClient.GetSmsAccess();
        if (checkOperation.IsNotSuccess)
            return checkOperation.FlowError<CounterDto>();

        return  _truckTestedClient.DoWork();
    }
    
    public CounterView GetCounter()
    {
        var counter = _truckTestedClient.DoWork();
   
        return new CounterView
        {
            Count = counter.Count
        };
    }
}