using System.Collections.Generic;

namespace FindNumbersSuchThat;

public class NumberGenerator
{
    private readonly List<Func<int, int, bool>> _conditions = new();
    private readonly List<int> _conditionsInputs = new();
    private readonly Random _rand = new();
    private readonly List<int> _discardedNumbers = new();
    private int _minValue = 0;
    private int _maxValue = 1000;

    /// <summary>
    /// Add a condition delegate along with the parameter it should take if it's needed
    /// </summary>
    /// <param name="condition">Func delegate containing reference to the corresponding condition check method</param>
    /// <param name="conditionInput">Input for the delegate, if it doesn't need any, the default value will be 0 (temporarily, until I find a more flexible solution)</param>
    public void AddCondition(Func<int, int, bool> condition, int conditionInput = 0)
    {
        _conditions.Add(condition);
        _conditionsInputs.Add(conditionInput);
    }
    /// <summary>
    /// Exclude specified numbers from being included in the output
    /// </summary>
    /// <param name="numbers">List of numbers to be excluded</param>
    public void ExcludeNumbers(IEnumerable<int> numbers)
    {
        _discardedNumbers.AddRange(numbers);
    }

    public void ResetExcludedNumbers()
    {
        _discardedNumbers.Clear();
    }

    /// <summary>
    /// Specify the range of generated numbers. WARNING: make sure there's enough possible outcomes for the specified conditions! <br></br>
    /// E.g. If you want to generate numbers in range of 1 to 10, but add a condition to only generate prime numbers excluding 2, 3, 5, 7 then you'll get nothing!
    /// </summary>
    /// <param name="min">Minimal possible output (inclusive)</param>
    /// <param name="max">Maximal possible output (inclusive)</param>
    public void SetRange(int min, int max)
    {
        _minValue = min;
        _maxValue = max;
    }

    /// <summary>
    /// Function which generates an array of specified length, which contains numbers that satisfy all specified conditions
    /// </summary>
    /// <param name="arrayLength">How many numbers should the generated array be populated with</param>
    /// <param name="allowDuplicates">Should duplicates be allowed? Default: false <br></br> 
    /// REMEMBER that this parameter only disallows duplicates in THIS batch of numbers, and not in subsequent ones</param>
    /// <returns>Array of numbers fulfilling specified conditions</returns>
    public IEnumerable<int> GenerateNumbersArray(int arrayLength, bool allowDuplicates = false)
    {
        var generatedNumbers = new int[arrayLength];
        List<int> triedNumbers = new();

        for (var i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] += GenerateCertainNumber(allowDuplicates, triedNumbers);
        }
        return generatedNumbers;
    }

    /// Function to generate a number which fulfills specified conditions
    private int GenerateCertainNumber(bool allowDuplicates, List<int> triedNumbers)
    {
        int randomNumber;
        var randomNumberPassedConditions = false;

        int possibleOutcomesBeforeConditions = _maxValue - (_minValue - 1) - _discardedNumbers.Where<int>(number => number <= _maxValue).Count();
        do
        {
            randomNumber = _rand.Next(_minValue, _maxValue + 1);
            if (triedNumbers.Count >= possibleOutcomesBeforeConditions)
            {
                string conditions = "";
                foreach (var condition in _conditions) conditions += "\n" + condition.Method.Name;
                throw new Exception($"Make sure it's possible to generate this amount of numbers for the conditions you've specified!\n" +
                    $"Amount of possible outcomes BEFORE applying conditions: {possibleOutcomesBeforeConditions}\n" +
                    $"Specified conditions: {conditions}");
            }
            if (_discardedNumbers.Contains(randomNumber) || triedNumbers.Contains(randomNumber)) continue;
            if (!allowDuplicates) triedNumbers.Add(randomNumber);
            for (var i = 0; i < _conditions.Count; i++)
            {
                if (!_conditions[i](randomNumber, _conditionsInputs[i]))
                {
                    randomNumberPassedConditions = false;
                    if (allowDuplicates) triedNumbers.Add(randomNumber);
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