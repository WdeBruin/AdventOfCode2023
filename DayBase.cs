namespace Advent;

public abstract class DayBase
{
    public abstract void Run();

    protected static void WriteLine(string val)
    {
        Console.WriteLine(val);
    }

    protected static void Write(string val)
    {
        Console.Write(val);
    }

    protected static string[] ReadInput(string fileName)
    {
        return File.ReadAllLines($"Input/{fileName}");
    }
}
