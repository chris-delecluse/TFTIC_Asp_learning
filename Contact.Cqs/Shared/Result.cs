namespace Contact.Cqs.Shared;

public class Result
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; init; }

    private Result(bool isSuccess, string? message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success() => new Result(true, null);

    public static Result Failure(string message) => new Result(false, message);
}
