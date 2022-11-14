using System;
using System.Collections.Generic;

public class NumberGenerator
{
    List<Func<int, int, bool>> _conditions = new();
    List<int> _conditionsInputs = new();
    Random _rand = new();

    public void AddCondition(Func<int, int, bool> condition, int conditionInput)
    {
        _conditions.Add(condition);
        _conditionsInputs.Add(conditionInput);
    }
    
    /// Function which generates an array of specified length
    public int[] GenerateNumbersArray(int arrayLength)
    {
        int[] generatedNumbers = new int[arrayLength];

        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] += GenerateCertainNumber();
        }
        return generatedNumbers;
    }

    /// Function to generate a number which fulfills specified conditions
    int GenerateCertainNumber()
    {
        int randomNumber;
        var randomNumberPassedConditions = false;
        do
        {
            randomNumber = _rand.Next(1, 1000);
            for (int i = 0; i < _conditions.Count; i++)
            {
                if (!_conditions[i](randomNumber, _conditionsInputs[i]))
                {
                    randomNumberPassedConditions = false;
                    break;
                }
                else
                {
                    randomNumberPassedConditions = true;
                }
            }
        } while (!randomNumberPassedConditions);
        return randomNumber;
    }
}