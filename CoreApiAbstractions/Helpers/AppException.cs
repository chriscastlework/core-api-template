using System.Globalization;

namespace CoreApiAbstractions.Helpers;

/// <summary>
/// App Exception will be shown to the user other exceptions will be logged
/// </summary>
public class AppException : Exception
{
    public AppException(string message, Exception? ex) : base(message, ex) { }

    public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}