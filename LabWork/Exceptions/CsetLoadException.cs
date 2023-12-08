namespace LabWork.Exceptions;

internal class CsetLoadException : CsetException
{
    public CsetLoadException(string? message = "Возникла ошибка при загрузке множества", 
        Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
