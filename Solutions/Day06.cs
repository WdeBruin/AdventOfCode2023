using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using Advent.Extensions;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day06 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day06.txt");

        var time = long.Parse(string.Concat(lines[0].Split(':')[1].Where(c => !char.IsWhiteSpace(c))));
        var target = long.Parse(string.Concat(lines[1].Split(':')[1].Where(c => !char.IsWhiteSpace(c))));

        Console.WriteLine($"Time: {time} -- Target: {target}");

        int answer = 0;

        for (long i = 0; i < time; i++)
        {
            long speed = i;
            long runTime = time - i;
            double dist = (double)runTime * speed;

            if (dist > target)
                answer++;
        }

        WriteLine($"{answer}");
    }
}
