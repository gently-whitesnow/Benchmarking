namespace Benchmarking.LoadsOperationResultStand.Entities;

public sealed class LoadsOperationResult<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;
    public T Result { get; private set; }
    public ILoadsOperationError Error { get; private set; }

    private LoadsOperationResult()
    {
    }

    internal static LoadsOperationResult<T> Failed(ILoadsOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new LoadsOperationResult<T>
        {
            Error = error,
            IsSuccess = false
        };
    }

    public LoadsOperationResult<TTarget> FlowError<TTarget>()
    {
        return LoadsOperationResult<TTarget>.Failed(Error);
    }

    public LoadsOperationResult FlowError()
    {
        return LoadsOperationResult.Failed(Error);
    }

    internal static LoadsOperationResult<T> Success(T result)
    {
        return new LoadsOperationResult<T>
        {
            Result = result,
            IsSuccess = true
        };
    }

    public static implicit operator LoadsOperationResult<T>(T result)
    {
        return Success(result);
    }
}

public sealed class LoadsOperationResult
{
    private LoadsOperationResult()
    {
    }

    public ILoadsOperationError Error { get; private set; }

    public bool IsSuccess { get; private set; }
    public bool IsNotSuccess => !IsSuccess;

    public LoadsOperationResult<TTarget> FlowError<TTarget>()
    {
        return LoadsOperationResult<TTarget>.Failed(Error);
    }

    public LoadsOperationResult FlowError()
    {
        return this;
    }

    internal static LoadsOperationResult Failed(ILoadsOperationError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new LoadsOperationResult
        {
            Error = error,
            IsSuccess = false
        };
    }

    internal static LoadsOperationResult Success()
    {
        return new LoadsOperationResult
        {
            IsSuccess = true
        };
    }
}
