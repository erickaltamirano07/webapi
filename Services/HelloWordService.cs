public class HelloWordService: IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}