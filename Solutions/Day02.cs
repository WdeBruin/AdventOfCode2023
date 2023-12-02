namespace Advent.Solutions;

public class Day02 : DayBase
{
    public override void Run()
    {
        /*
            12 red cubes, 13 green cubes, and 14 blue
            Sum of ID of games that are possible
        */

        var lines = ReadInput("Day02.txt");
        int answer = 0;

        int redMax = 12;
        int greenMax = 13;
        int blueMax = 14;

        foreach(var line in lines)
        {
            int id = int.Parse(line[line.IndexOf(' ')..line.IndexOf(':')]);
            string[] sets = line.Split(':')[1].Split(';');

            // int red = 0;
            // int green = 0;
            // int blue = 0;
            bool invalid = false;;

            foreach(var set in sets)
            {
                int redI = set.IndexOf("red");
                int greenI = set.IndexOf("green");
                int blueI = set.IndexOf("blue");

                if (redI != -1)
                {
                    int val = int.Parse(set[..redI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));
                    if (val > redMax && invalid == false) invalid = true;
                    //red += int.Parse(set[..redI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));

                }
                if (greenI != -1)
                {
                    int val = int.Parse(set[..greenI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));
                    if (val > greenMax && invalid == false) invalid = true;
                    //green += int.Parse(set[..greenI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));
                }
                if (blueI != -1)
                {
                    int val = int.Parse(set[..blueI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));
                    if (val > blueMax && invalid == false) invalid = true;
                    //blue += int.Parse(set[..blueI].Split(' ').Last(x => !string.IsNullOrEmpty(x)));
                }
            }

            if (invalid == false) answer += id;
            //if (red <= redMax && green <= greenMax && blue <= blueMax) answer += id;
        }

        WriteLine($"{answer}");        
    }
}
