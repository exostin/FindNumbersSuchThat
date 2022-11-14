namespace FindRandomNumbersSuchThat;

public static class Conditions
{
    // Predicate functions (conditions)
    private static bool DivisibleBy(int inputNumber, int divisor)
    {
        return inputNumber % divisor == 0;
    }

    private static bool HigherThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber > numberToCompareTo;
    }

    private static bool LowerThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber < numberToCompareTo;
    }

    // Delegates of predicate functions
    public static readonly Func<int, int, bool> IsDivBy = DivisibleBy;
    public static readonly Func<int, int, bool> IsHigherThan = HigherThan;
    public static readonly Func<int, int, bool> IsLowerThan = LowerThan;
}