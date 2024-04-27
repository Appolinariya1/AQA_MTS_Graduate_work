namespace Graduate_work.Models;

public class BaseApiResult<T>
{
    public string Status { get; set; }
    public T? Result { get; set; }
    public string ErrorMessage { get; set; }
}