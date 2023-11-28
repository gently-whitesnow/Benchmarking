namespace Benchmarking.ImplicitableOperationResultStand.Entities;

public class BadRequestError: IOperationError
{
    public string Error { get; set; }
    public string Message { get; set; }
}