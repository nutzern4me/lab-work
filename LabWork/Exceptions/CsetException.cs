namespace LabWork.Exceptions;

internal class CsetException : Exception
{
    public CsetException(string? message = "Возникла ошибка при работе с множеством", Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
