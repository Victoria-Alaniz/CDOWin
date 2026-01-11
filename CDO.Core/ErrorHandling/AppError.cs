namespace CDO.Core.ErrorHandling;

public sealed record AppError(
    ErrorKind Kind,
    string Message,
    int? StatusCode = null,
    Exception? Exception = null
);
