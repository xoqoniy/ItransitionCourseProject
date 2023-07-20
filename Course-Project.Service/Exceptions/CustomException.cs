
namespace Course_Project.Service.Exceptions;


public class CustomException : Exception
{
    public int Code { get; set; }
    public CustomException(int code, string message = "Something went wrong") : base(message)
    {
        this.Code = code;
    }
}
