namespace Benchmarking.AsyncLoadsOperationResultStand.Entities;

public sealed class AsyncLoadsOperationResult<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;
    public T Result { get; private set; }
    public IAsyncLoadsOperationError Error { get; private set; }

    private AsyncLoadsOperationResult()
    {
    }

    internal static AsyncLoadsOperationResult<T> Failed(IAsyncLoadsOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new AsyncLoadsOperationResult<T>
        {
            Error = error,
            IsSuccess = false
        };
    }

    public AsyncLoadsOperationResult<TTarget> FlowError<TTarget>()
    {
        return AsyncLoadsOperationResult<TTarget>.Failed(Error);
    }

    public AsyncLoadsOperationResult FlowError()
    {
        return AsyncLoadsOperationResult.Failed(Error);
    }

    internal static AsyncLoadsOperationResult<T> Success(T result)
    {
        return new AsyncLoadsOperationResult<T>
        {
            Result = result,
            IsSuccess = true
        };
    }

    public static implicit operator AsyncLoadsOperationResult<T>(T result)
    {
        return Success(result);
    }
}

public sealed class AsyncLoadsOperationResult
{
    private AsyncLoadsOperationResult()
    {
    }

    public IAsyncLoadsOperationError Error { get; private set; }

    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;

    public AsyncLoadsOperationResult<TTarget> FlowError<TTarget>()
    {
        return AsyncLoadsOperationResult<TTarget>.Failed(Error);
    }

    public AsyncLoadsOperationResult FlowError()
    {
        return this;
    }

    internal static AsyncLoadsOperationResult Failed(IAsyncLoadsOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new AsyncLoadsOperationResult
        {
            Error = error,
            IsSuccess = false
        };
    }

    internal static AsyncLoadsOperationResult Success()
    {
        return new AsyncLoadsOperationResult
        {
            IsSuccess = true
        };
    }
}
