namespace FindRandomNumbersSuchThat;

public static class Conditions
{
    private static bool CheckIfDivisibleBy(int inputNumber, int divisor)
    {
        return inputNumber % divisor == 0;
    }

    private static bool CheckIfHigherThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber > numberToCompareTo;
    }

    private static bool CheckIfLowerThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber < numberToCompareTo;
    }

    private static bool CheckIfSemiPrime(int inputNumber, int numberToCompareTo)
    {
        int count = 0;

        for (int i = 2; count < 2 && i * i <= inputNumber; ++i)
        {
            while (inputNumber % i == 0)
            {
                inputNumber /= i;
                ++count;
            }
        }
        if (inputNumber > 1) count++;

        return count == 2;
    }

    // Delegates of conditions

    public static readonly Func<int, int, bool> IsDivBy = CheckIfDivisibleBy;
    public static readonly Func<int, int, bool> IsHigherThan = CheckIfHigherThan;
    public static readonly Func<int, int, bool> IsLowerThan = CheckIfLowerThan;
    public static readonly Func<int, int, bool> IsSemiPrime = CheckIfSemiPrime;
}