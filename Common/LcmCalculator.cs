// ChatGPT result, experimented to see if it could help me with this and it can :)
namespace Advent.Common;
public class LCMCalculator
{
    public long CalculateLCM(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return 0;

        long lcm = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            lcm = CalculateLCM(lcm, numbers[i]);
        }

        return lcm;
    }

    private long CalculateLCM(long a, long b)
    {
        if (a == 0 || b == 0)
            return 0;

        return Math.Abs(a * b) / CalculateGCD(a, b);
    }

    private long CalculateGCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}