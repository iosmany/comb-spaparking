namespace COMB.SpaParking.Base.Result;

public sealed class Error
{
    public string Message { get; }
    private Error(string message)
    {
        Message = message;
    }

    public static Error Create(string message)
    {
        return new Error(message);
    }
}
