namespace FindRandomNumbersSuchThat;

public class NumberGenerator
{
    private readonly List<Func<int, int, bool>> _conditions = new();
    private readonly List<int> _conditionsInputs = new();
    private readonly Random _rand = new();

    private readonly List<int> discardedNumbers = new();

    public void AddCondition(Func<int, int, bool> condition, int conditionInput)
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
            if (discardedNumbers.Contains(randomNumber)) continue;
            if (!allowDuplicates) discardedNumbers.Add(randomNumber);
            for (var i = 0; i < _conditions.Count; i++)
            {
                if (!_conditions[i](randomNumber, _conditionsInputs[i]))
                {
                    randomNumberPassedConditions = false;
                    if (allowDuplicates) discardedNumbers.Add(randomNumber);
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