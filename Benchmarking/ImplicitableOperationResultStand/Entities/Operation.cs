namespace Benchmarking.ImplicitableOperationResultStand.Entities;

public record Operation<TValue>
{
    public TValue Value { get; init; }
    public IOperationError Error { get; init; }
    
    public bool IsSuccess => !IsError;
    public bool IsError { get; init; }

    public Operation(TValue value)
    {
        Value = value;
    }

    public Operation(IOperationError error)
    {
        Error = error;
        IsError = true;
    }

    public static implicit operator Operation<TValue>(TValue value) => new(value);
    
    public static implicit operator Operation<TValue>(IOperationError error) => new(error);
}

public record Operation
{
    public IOperationError Error { get; init; }
    
    public bool IsSuccess => !IsError;
    public bool IsError { get; init; }

    public Operation()
    {
    }

    public Operation(IOperationError error)
    {
        Error = error;
        IsError = true;
    }
    
    public static implicit operator Operation(IOperationError error) => new(error);
}