namespace Benchmarking.LoadsOperationResultStand.Entities;

public class LoadsBadRequestError : ILoadsOperationError
{
    public string Error { get; set; }
    public string Message { get; set; }
}