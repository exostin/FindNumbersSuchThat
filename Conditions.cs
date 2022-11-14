namespace FindNumbersSuchThat;

public static class Conditions
{
    #region Conditions methods

    private static bool CheckIfDivisibleBy(int inputNumber, int divisor)
    {
        return inputNumber % divisor == 0;
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

    #endregion

    #region Delegates of conditions

    public static readonly Func<int, int, bool> IsDivisibleBy = CheckIfDivisibleBy;
    public static readonly Func<int, int, bool> IsSemiPrime = CheckIfSemiPrime;

    #endregion
}