using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var _numberGenerator = new NumberGenerator();

        _numberGenerator.AddCondition(Conditions.higherThan, 3);
        _numberGenerator.AddCondition(Conditions.lowerThan, 200);
        _numberGenerator.AddCondition(Conditions.divBy, 3);

        var numArray = _numberGenerator.GenerateNumbersArray(15);
        foreach (int number in numArray)
        {
            Console.WriteLine(number);
        }
    }
}
