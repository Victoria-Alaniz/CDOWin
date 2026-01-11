namespace CDO.Core.ErrorHandling;

public enum ErrorKind {
    None,
    Network,
    Unauthorized,
    Forbidden,
    NotFound,
    Validation,
    Conflict,
    Server,
    Timeout,
    Cancelled,
    Unknown
}