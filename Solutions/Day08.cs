using Advent.Common;

namespace Advent.Solutions;

public class Day08 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day08.txt");
        string instructions = lines[0];

        BinaryTree<string> binaryTree = new();

        var line = lines.First(x => x[0..2] == "AAA");

        string location = line[0..2];
        var left = line[7..9];
        var right = line[12..14];
        binaryTree.Add(location);
        binaryTree.Add(left);
        binaryTree.Add(right);

        int i = 0;
        int depth = 0;
        Node<string> currentNode = binaryTree.Root;
        while (location != "ZZZ")
        {
            char dir = instructions[i]; // L or R
            currentNode = dir == 'L' ? currentNode.Left : currentNode.Right;

            if (currentNode.Left == null)
            {
                line = lines.First(x => x[0..2] == currentNode.Value);
                currentNode.Add(line[7..9]);
                currentNode.Add(line[12..14]);
            }


            i = i < instructions.Length ? i + 1 : 0;
            depth++;
        }

        Console.WriteLine($"Depth: {depth}");
    }
}
