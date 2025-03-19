namespace TxtReader.Task2Singleton;

public class Singleton
{
    private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

    private Singleton() { }

    public static Singleton Instance => _instance.Value;
}
