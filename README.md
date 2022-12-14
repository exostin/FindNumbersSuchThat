# Find Numbers Such That

As the title suggests, this console app is an easily extensible generator of numbers that satisfy given conditions.*

While brute-force searching for numbers which fulfill hard-coded conditions is rather easy, this project aims to be a fully universal and extensible solution for usage in cases where there are many conditions, allowing to freely pick and swap between them.

*Currently it only outputs random numbers fullfilling specified conditions, but I will soon also add the functionality to find ALL numbers that do so.

## Usage

`Conditions.cs`

1. Create a method for the condition you want to satisfy, and a delegate containing that method. **Example:**

```csharp
private static bool CheckIfDivisibleBy(int inputNumber, int divisor)
{
    return inputNumber % divisor == 0;
}
public static readonly Func<int, int, bool> IsDivisibleBy = CheckIfDivisibleBy;
```

`Program.cs`

2. Create `NumberGenerator` class instance

```csharp
var numberGenerator = new NumberGenerator();
```

3. Add conditions to the `NumberGenerator` instance. **Example:**

```csharp
numberGenerator.SetRange(1, 1000);
numberGenerator.ExcludeNumbers(new List<int> { 4, 6, 9, 10, 14, 15, 21, 22 });
numberGenerator.AddCondition(Conditions.IsDivisibleBy, 3);
numberGenerator.AddCondition(Conditions.IsSemiPrime);
```

4. Generate your numbers. **Example:** this code will generate two arrays containing 10 numbers. The first generation won't allow duplicate numbers in its output, while the second will. Between those two runs, I'll also reset excluded numbers, and instead exclude the ones that have been generated by the previous run

```csharp
var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);
numberGenerator.ResetExcludedNumbers();
numberGenerator.ExcludeNumbers(numArrayWithoutDuplicates);
var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);
```

Example output of the code above:

```
687
237
813
849
807
951
933
177
717
213

537
537
201
411
51
393
789
831
447
21
```
