namespace FindRandomNumbersSuchThat;

public class NumberGenerator
{
    private readonly List<Func<int, int, bool>> _conditions = new();
    private readonly List<int> _conditionsInputs = new();
    private readonly Random _rand = new();

    public void AddCondition(Func<int, int, bool> condition, int conditionInput)
    {
        _conditions.Add(condition);
        _conditionsInputs.Add(conditionInput);
    }
    
    /// <summary>
    /// Function which generates an array of specified length, which contains numbers that satisfy all specified conditions
    /// </summary>
    /// <param name="arrayLength">How many numbers should the generated array be populated with</param>
    /// <returns>Array of numbers fulfilling specified conditions</returns>
    public IEnumerable<int> GenerateNumbersArray(int arrayLength)
    {
        var generatedNumbers = new int[arrayLength];

        for (var i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] += GenerateCertainNumber();
        }
        return generatedNumbers;
    }

    /// Function to generate a number which fulfills specified conditions
    private int GenerateCertainNumber()
    {
        int randomNumber;
        var randomNumberPassedConditions = false;
        do
        {
            randomNumber = _rand.Next(1, 1000);
            for (var i = 0; i < _conditions.Count; i++)
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