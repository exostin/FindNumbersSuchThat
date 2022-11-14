namespace FindNumbersSuchThat;

public static class Program
{
    public static void Main()
    {
        var numberGenerator = new NumberGenerator();

        #region Usage example

        numberGenerator.AddCondition(Conditions.IsHigherThan, 3);
        numberGenerator.AddCondition(Conditions.IsLowerThan, 200);
        numberGenerator.AddCondition(Conditions.IsDivBy, 3);
        numberGenerator.AddCondition(Conditions.IsSemiPrime);
        numberGenerator.ExcludeNumbers(new List<int> { 4, 6, 9, 10, 14, 15, 21, 22 });

        var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);
        var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);

        foreach (int number in numArrayWithDuplicates)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        foreach (int number in numArrayWithoutDuplicates)
        {
            Console.WriteLine(number);
        }

        #endregion
    }
}