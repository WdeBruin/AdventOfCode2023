using Advent.Common;

namespace Advent.Solutions;

public class Day08 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day08.txt");
        string instructions = lines[0];

        var startLines = lines[2..].Where(x => x[2] == 'A').Order().ToArray();
        var endLines = lines[2..].Where(x => x[2] == 'Z').Order().ToArray();

        int[] results = new int[startLines.Length];

        for (int i = 0; i < startLines.Length; i++)
        {
            BinaryTree<string> binaryTree = new();

            string location = startLines[i][0..3];
            var left = startLines[i][7..10];
            var right = startLines[i][12..15];
            binaryTree.Add(location);
            Node<string> currentNode = binaryTree.Root;
            currentNode.Add(left);
            currentNode.Add(right);

            int ins = 0;
            int steps = 0;

            while (currentNode.Value[2] != 'Z')
            {
                char dir = instructions[ins]; // L or R
                currentNode = dir == 'L' ? currentNode.Left : currentNode.Right;

                if (currentNode.Left == null)
                {
                    var line = lines[2..].First(x => x[0..3] == currentNode.Value);
                    currentNode.Add(line[7..10]);
                    currentNode.Add(line[12..15]);
                }

                ins = ins < instructions.Length - 1 ? ins + 1 : 0;
                steps++;
            }
            Console.WriteLine($"Steps: {steps}");
            results[i] = steps;
        }

        var lcm = new LCMCalculator();
        var r = lcm.CalculateLCM(results);

        Console.WriteLine($"ChatGPT LCM: {r}");
    }
}
