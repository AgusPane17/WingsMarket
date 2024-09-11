public class CustomError : Exception{

    public int code { get;}
    public CustomError(
        string message, 
        int code, 
        Exception? innerException) 
        : base(message,innerException)
    {
        this.code = code;
    }
    public CustomError(string name, 
        string message, 
        int code, 
        Exception? innerException)
        : base(message, innerException)
    {
        this.Data["Name"] = name;
        this.code = code;
    }
}