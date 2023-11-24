using Benchmarking.TrucksOperationResult.Entities;

namespace Benchmarking.TrucksOperationResultStand.Entities;

public record struct TruckOperationResult<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;
    public T Value { get; private set; }
    public ITruckOperationError Error { get; private set; }
    
    internal static TruckOperationResult<T> Failed(ITruckOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new TruckOperationResult<T>
        {
            Error = error,
            IsSuccess = false
        };
    }

    public TruckOperationResult<TTarget> FlowError<TTarget>()
    {
        return TruckOperationResult<TTarget>.Failed(Error);
    }

    public TruckOperationResult FlowError()
    {
        return TruckOperationResult.Failed(Error);
    }

    internal static TruckOperationResult<T> Success(T result)
    {
        return new TruckOperationResult<T>
        {
            Value = result,
            IsSuccess = true
        };
    }

    public static implicit operator TruckOperationResult<T>(T result)
    {
        return Success(result);
    }
}

public record struct TruckOperationResult
{
    public ITruckOperationError Error { get; private set; }

    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;

    public TruckOperationResult<TTarget> FlowError<TTarget>()
    {
        return TruckOperationResult<TTarget>.Failed(Error);
    }

    public TruckOperationResult FlowError()
    {
        return this;
    }

    internal static TruckOperationResult Failed(ITruckOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new TruckOperationResult
        {
            Error = error,
            IsSuccess = false
        };
    }

    internal static TruckOperationResult Success()
    {
        return new TruckOperationResult
        {
            IsSuccess = true
        };
    }
}
