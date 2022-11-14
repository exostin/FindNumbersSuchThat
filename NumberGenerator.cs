namespace FindNumbersSuchThat;

public class NumberGenerator
{
    private readonly List<Func<int, int, bool>> _conditions = new();
    private readonly List<int> _conditionsInputs = new();
    private readonly Random _rand = new();

    private readonly List<int> _discardedNumbers = new();

    /// <summary>
    /// Add a condition delegate along with the parameter it should take
    /// </summary>
    /// <param name="condition">Func delegate containing reference to the corresponding condition check method</param>
    /// <param name="conditionInput">Input for the delegate, if it doesn't need any, the default value will be 0 (temporarily, until I find a more flexible solution)</param>
    public void AddCondition(Func<int, int, bool> condition, int conditionInput = 0)
    {
        _conditions.Add(condition);
        _conditionsInputs.Add(conditionInput);
    }

    /// <summary>
    /// Function which generates an array of specified length, which contains numbers that satisfy all specified conditions
    /// </summary>
    /// <param name="arrayLength">How many numbers should the generated array be populated with</param>
    /// <param name="allowDuplicates">Should duplicates be allowed? Default: false</param>
    /// <returns>Array of numbers fulfilling specified conditions</returns>
    public IEnumerable<int> GenerateNumbersArray(int arrayLength, bool allowDuplicates = false)
    {
        var generatedNumbers = new int[arrayLength];

        for (var i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] += GenerateCertainNumber(allowDuplicates);
        }
        return generatedNumbers;
    }

    /// Function to generate a number which fulfills specified conditions
    private int GenerateCertainNumber(bool allowDuplicates = false)
    {
        int randomNumber;
        var randomNumberPassedConditions = false;
        do
        {
            randomNumber = _rand.Next(1, 1000);
            if (_discardedNumbers.Contains(randomNumber)) continue;
            if (!allowDuplicates) _discardedNumbers.Add(randomNumber);
            for (var i = 0; i < _conditions.Count; i++)
            {
                if (!_conditions[i](randomNumber, _conditionsInputs[i]))
                {
                    randomNumberPassedConditions = false;
                    if (allowDuplicates) _discardedNumbers.Add(randomNumber);
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