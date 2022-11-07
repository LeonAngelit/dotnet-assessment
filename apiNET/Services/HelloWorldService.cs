public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hellor World!";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}
