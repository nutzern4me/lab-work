namespace LabWork.Exceptions;

internal class CsetSaveException : CsetException
{
    public CsetSaveException(string? message = "Возникла ошибка при сохранении множества", 
        Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
