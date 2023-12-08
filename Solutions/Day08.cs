using System.Diagnostics;
using Advent.Common;

namespace Advent.Solutions;

public class Day08 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day08.txt");
        string instructions = lines[0];

        var allLines = lines[2..];


        var startPoints = lines[2..].Where(l => l[2] == 'A').Select(y => y[0..3]).ToArray();
        var bsts = new List<BinarySearchTree<string>>();

        var time = new Stopwatch();
        time.Start();
        foreach (var startPoint in startPoints)
        {
            BinarySearchTree<string> binaryTree = new();
            binaryTree.Insert(startPoint);
            binaryTree.Traverse((n) =>
            {
                var l = lines[2..].First(x => x[0..3] == n.Value);
                string[] s = {l[7..10], l[12..15]};
                binaryTree.Insert(s);
            }, TraversalType.InOrder);

            bsts.Add(binaryTree);
        }
        Console.WriteLine($"Time passed: {time.Elapsed}");

        int i = 0;
        int steps = 0;

        // for 8b: Must setup the full tree
        // Then after I got full tree, do binary search.        

        Console.WriteLine($"Steps: {steps}");
    }
}
