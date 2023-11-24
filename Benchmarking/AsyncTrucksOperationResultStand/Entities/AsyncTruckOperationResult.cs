namespace Benchmarking.AsyncTrucksOperationResultStand.Entities;

public record struct AsyncTruckOperationResult<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;
    public T Value { get; private set; }
    public IAsyncTruckOperationError Error { get; private set; }
    
    internal static AsyncTruckOperationResult<T> Failed(IAsyncTruckOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new AsyncTruckOperationResult<T>
        {
            Error = error,
            IsSuccess = false
        };
    }

    public AsyncTruckOperationResult<TTarget> FlowError<TTarget>()
    {
        return AsyncTruckOperationResult<TTarget>.Failed(Error);
    }

    public AsyncTruckOperationResult FlowError()
    {
        return AsyncTruckOperationResult.Failed(Error);
    }

    internal static AsyncTruckOperationResult<T> Success(T result)
    {
        return new AsyncTruckOperationResult<T>
        {
            Value = result,
            IsSuccess = true
        };
    }

    public static implicit operator AsyncTruckOperationResult<T>(T result)
    {
        return Success(result);
    }
}

public record struct AsyncTruckOperationResult
{
    public IAsyncTruckOperationError Error { get; private set; }

    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;

    public AsyncTruckOperationResult<TTarget> FlowError<TTarget>()
    {
        return AsyncTruckOperationResult<TTarget>.Failed(Error);
    }

    public AsyncTruckOperationResult FlowError()
    {
        return this;
    }

    internal static AsyncTruckOperationResult Failed(IAsyncTruckOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new AsyncTruckOperationResult
        {
            Error = error,
            IsSuccess = false
        };
    }

    internal static AsyncTruckOperationResult Success()
    {
        return new AsyncTruckOperationResult
        {
            IsSuccess = true
        };
    }
}
