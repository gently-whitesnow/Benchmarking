namespace Benchmarking.AsyncLoadsOperationResultStand.Entities;

public class AsyncLoadsBadRequestError : IAsyncLoadsOperationError
{
    public string Error { get; set; }
    public string Message { get; set; }
}