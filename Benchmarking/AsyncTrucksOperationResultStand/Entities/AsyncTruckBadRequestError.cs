namespace Benchmarking.AsyncTrucksOperationResultStand.Entities;

public class AsyncTruckBadRequestError : IAsyncTruckOperationError
{
    public string Error { get; set; }
    public string Message { get; set; }
}