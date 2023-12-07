using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day05 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day05.txt").ToList();
        long answer = long.MaxValue;

        List<long> seeds = lines[0].Split(':')[1].Split(' ').ToList().Where(x => x != "").ToArray().ToLongArray().ToList();
        var seedSoilHeaderI = lines.FindIndex(x => x.Contains("seed-to-soil"));
        var soilFertHeaderI = lines.FindIndex(x => x.Contains("soil-to-fertilizer"));
        var fertWaterHeaderI = lines.FindIndex(x => x.Contains("fertilizer-to-water"));
        var waterLightHeaderI = lines.FindIndex(x => x.Contains("water-to-light"));
        var lightTempHeaderI = lines.FindIndex(x => x.Contains("light-to-temperature"));
        var tempHumHeaderI = lines.FindIndex(x => x.Contains("temperature-to-humidity"));
        var humLocHeaderI = lines.FindIndex(x => x.Contains("humidity-to-location"));

        var seedSoilMap = GetMapArrays(seedSoilHeaderI + 1, soilFertHeaderI - 2, lines);
        var soilFertMap = GetMapArrays(soilFertHeaderI + 1, fertWaterHeaderI - 2, lines);
        var fertWaterMap = GetMapArrays(fertWaterHeaderI + 1, waterLightHeaderI - 2, lines);
        var waterLightMap = GetMapArrays(waterLightHeaderI + 1, lightTempHeaderI - 2, lines);
        var lightTempMap = GetMapArrays(lightTempHeaderI + 1, tempHumHeaderI - 2, lines);
        var tempHumMap = GetMapArrays(tempHumHeaderI + 1, humLocHeaderI - 2, lines);
        var humLocMap = GetMapArrays(humLocHeaderI + 1, lines.Count - 1, lines);

        Console.WriteLine($"seedSoilMap {seedSoilMap.GetLength(0)}");
        Console.WriteLine($"soilFertMap {soilFertMap.GetLength(0)}");
        Console.WriteLine($"fertWaterMap {fertWaterMap.GetLength(0)}");
        Console.WriteLine($"waterLightMap {waterLightMap.GetLength(0)}");
        Console.WriteLine($"lightTempMap {lightTempMap.GetLength(0)}");
        Console.WriteLine($"tempHumMap {tempHumMap.GetLength(0)}");
        Console.WriteLine($"humLocMap {humLocMap.GetLength(0)}");

        var st = new Stopwatch();
        st.Start();

        for (int i = 0; i < seeds.Count; i += 2)
        {
            long s0 = seeds[i];
            long s1 = seeds[i + 1];

            Console.WriteLine($"Seed: {s0} - {s0 + s1}");

            Parallel.For(0, s1, j =>
            {
                long s = (long)(s0 + j);
            // for(long s = s0; s < s0+s1; s++)
            // {
                var seedSoil = Mapping(seedSoilMap, s);
                var soilFert = Mapping(soilFertMap, seedSoil);
                var fertWater = Mapping(fertWaterMap, soilFert);
                var waterLight = Mapping(waterLightMap, fertWater);
                var lightTemp = Mapping(lightTempMap, waterLight);
                var tempHum = Mapping(tempHumMap, lightTemp);
                var humLoc = Mapping(humLocMap, tempHum);

                if (humLoc < answer)
                {
                    Console.WriteLine($"New low: {humLoc} for seed {s}");
                    answer = humLoc;
                }  
            // }
            });
        }

        WriteLine($"{answer}");
        Console.WriteLine($"Time it took: {st.Elapsed}");
    }

    private long[,] GetMapArrays(int startLineI, int endLineI, List<string> lines)
    {
        var res = new long[endLineI - startLineI + 1, 3];

        for (int i = startLineI; i <= endLineI; i++)
        {
            var parts = lines[i].Split(' ').ToLongArray();
            res[i - startLineI, 0] = parts[0];
            res[i - startLineI, 1] = parts[1];
            res[i - startLineI, 2] = parts[2];
        }

        return res;
    }

    private long Mapping(long[,] map, long val)
    {
        bool result = false;    
        long res = val; 

        for (int i = 0; i < map.GetLength(0); i++)
        {
            //[i,0] destStart 
            //[i,1] sourceStart
            //[i,2] rangeLength       
                        
            if (val >= map[i, 1] && val <= map[i, 1] + map[i, 2])
            {
                res = map[i, 0] + val - map[i, 1];
                break;
            }
        }

        return res;
    }

}
