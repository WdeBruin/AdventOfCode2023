using System.Collections;

namespace Advent.Extensions;

public static class StackExtensions
{
    public static void Print(this Stack<string>[] stacks)
    {
        var stackSize = stacks.Max(x => x.Count);

        for (int i = 1; i <= stacks.Count(); i++)
        {
            Console.Write($" {i} ");
        }
        Console.Write("\n");
        for (int i = 0; i < stackSize; i++)
        {
            foreach (var stack in stacks)
            {
                if(i < stack.Count())
                    Console.Write($"{stack.ElementAt(i)}");
                else
                {
                    Console.Write("   ");
                }
            }
            Console.Write("\n");
        }
        
    }
}