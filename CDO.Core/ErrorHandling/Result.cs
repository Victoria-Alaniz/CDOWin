namespace CDO.Core.ErrorHandling;

public class Result {
    public bool IsSuccess { get; }
    public AppError? Error { get; }

    protected Result(bool success, AppError? error) {
        IsSuccess = success;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Fail(AppError error) => new(false, error);
}

public sealed class Result<T> : Result {
    public T? Value { get; }

    private Result(bool success, T? value, AppError? error) : base(success, error) {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static new Result<T> Fail(AppError error) => new(false, default, error);
}
