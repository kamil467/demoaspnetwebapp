namespace DemoWebApplication.Utility;

public class ServiceLogger: IServiceLogger
{
    public ServiceLogger()
    {
        Console.WriteLine($"Service Logger Instance Created- Instance ID: ${Guid.NewGuid()}");
    }
    public void Log(string categoryName, string message)
    {
        Console.WriteLine($"{categoryName} - {message}");
    }
}