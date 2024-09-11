
namespace WingsMarket.Errors.FactoryErrors;
public static class ErrorFactory
{
    public static void CreateError(string name, string message, int code, Exception? cause)
    {
        var error = new CustomError(name, message, code, cause);
        throw error;
    }
}