namespace FindRandomNumbersSuchThat;

public static class Program
{
    public static void Main()
    {
        var numberGenerator = new NumberGenerator();
        
        #region Usage example
        
        numberGenerator.AddCondition(Conditions.IsHigherThan, 3);
        numberGenerator.AddCondition(Conditions.IsLowerThan, 200);
        numberGenerator.AddCondition(Conditions.IsDivBy, 3);

        var numArray = numberGenerator.GenerateNumbersArray(15);
        foreach (int number in numArray)
        {
            Console.WriteLine(number);
        }

        #endregion
    }
}