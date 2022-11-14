public static class Conditions
{
    // Predicate functions (for specifying conditions)
    public static bool DivBy(int inputNumber, int divisor)
    {
        return inputNumber % divisor == 0;
    }
    public static bool HigherThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber > numberToCompareTo;
    }
    public static bool LowerThan(int inputNumber, int numberToCompareTo)
    {
        return inputNumber < numberToCompareTo;
    }

    // Delegates of predicate functions
    public static Func<int, int, bool> divBy = DivBy;
    public static Func<int, int, bool> higherThan = HigherThan;
    public static Func<int, int, bool> lowerThan = LowerThan;
}