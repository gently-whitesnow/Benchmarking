using Benchmarking.TrucksOperationResult.Entities;

namespace Benchmarking.TrucksOperationResultStand.Entities;

public class TruckBadRequestError : ITruckOperationError
{
    public string Error { get; set; }
    public string Message { get; set; }
}