using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using Advent.Extensions;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day06 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day06.txt");

        var times = lines[0].Split(':')[1].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray();
        var targets = lines[1].Split(':')[1].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray();

        List<int> answers = new();

        Parallel.For(0, times.Length, i => {
            int time = times[i];
            int target = targets[i];

            int answerCount = 0;

            for(int j = 1; j < time; j++)
            {
                int speed = j;
                int runTime = time - j;
                double dist = (double)runTime * speed;

                if (dist > target)
                    answerCount++;
            }

            answers.Add(answerCount);
        });
        
        int answer = 1;
        for(int i = 0; i < answers.Count; i++)
            answer *= answers[i];

        WriteLine($"{answer}");
    }
}
