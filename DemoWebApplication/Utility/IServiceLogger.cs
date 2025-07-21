namespace DemoWebApplication.Utility;

public interface IServiceLogger
{
    void Log(string categoryName, string message);
}