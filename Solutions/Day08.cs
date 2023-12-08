using Advent.Common;

namespace Advent.Solutions;

public class Day08 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day08.txt");
        string instructions = lines[0];

        BinaryTree<string> binaryTree = new();

        var line = lines[2..].First(x => x[0..3] == "AAA");

        string location = line[0..3];
        var left = line[7..10];
        var right = line[12..15];
        binaryTree.Add(location);
        Node<string> currentNode = binaryTree.Root;
        currentNode.Add(left);
        currentNode.Add(right);

        int i = 0;
        int steps = 0;
        
        while (currentNode.Value != "ZZZ")
        {
            char dir = instructions[i]; // L or R
            currentNode = dir == 'L' ? currentNode.Left : currentNode.Right;

            if (currentNode.Left == null)
            {
                line = lines[2..].First(x => x[0..3] == currentNode.Value);
                currentNode.Add(line[7..10]);
                currentNode.Add(line[12..15]);
            }

            i = i < instructions.Length - 1 ? i + 1 : 0;
            steps++;
        }

        Console.WriteLine($"Steps: {steps}");
    }
}
