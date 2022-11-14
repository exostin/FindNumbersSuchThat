# Find Numbers Such That

As the title suggests, this console app is an easily extensible generator of random numbers that satisfy given conditions.

I will also soon add the functionality to find ALL numbers satisfying given conditions in the specified range.

## Usage

`Conditions.cs`

1. Create a method for the condition you want to satisfy, and a delegate containing that method. Example:

```csharp
private static bool CheckIfDivisibleBy(int inputNumber, int divisor)
{
    return inputNumber % divisor == 0;
}
public static readonly Func<int, int, bool> IsDivBy = CheckIfDivisibleBy;
```

`Program.cs`

2. Create `NumberGenerator` class instance

```csharp
var numberGenerator = new NumberGenerator();
```

3. Add conditions to the `NumberGenerator` instance. Example:

```csharp
numberGenerator.SetRange(1, 1000);
numberGenerator.ExcludeNumbers(new List<int> { 4, 6, 9, 10, 14, 15, 21, 22 });
numberGenerator.AddCondition(Conditions.IsDivisibleBy, 3);
numberGenerator.AddCondition(Conditions.IsSemiPrime);
```

4. Generate two arrays containing `n` numbers, first with duplicate numbers, second without. Example with `n = 10`:

```csharp
var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);
numberGenerator.ResetExcludedNumbers();
numberGenerator.ExcludeNumbers(numArrayWithoutDuplicates);
var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);
```

Printed arrays example:

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
