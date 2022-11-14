namespace FindNumbersSuchThat;

public static class Program
{
    public static void Main()
    {
        var numberGenerator = new NumberGenerator();

        #region Usage example
        numberGenerator.SetRange(1, 1000);
        numberGenerator.ExcludeNumbers(new List<int> { 4, 6, 9, 10, 14, 15, 21, 22 });
        numberGenerator.AddCondition(Conditions.IsDivisibleBy, 3);
        numberGenerator.AddCondition(Conditions.IsSemiPrime);

        var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);

        numberGenerator.ResetExcludedNumbers();
        numberGenerator.ExcludeNumbers(numArrayWithoutDuplicates);
        var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);

        
        foreach (int number in numArrayWithoutDuplicates)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        foreach (int number in numArrayWithDuplicates)
        {
            Console.WriteLine(number);
        }

        #endregion
    }
}