# Find Numbers Such That

This console app is an easily extensible generator for random numbers that satisfy given conditions.

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
numberGenerator.AddCondition(Conditions.IsHigherThan, 3);
numberGenerator.AddCondition(Conditions.IsLowerThan, 200);
numberGenerator.AddCondition(Conditions.IsDivBy, 3);
numberGenerator.AddCondition(Conditions.IsSemiPrime);
```

4. Generate two arrays containing `n` numbers, first with duplicate numbers, second without. Example with `n = 10`:

```csharp
var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);
var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);
```

Printed arrays example:

```
123
51
9
177
93
39
141
141
39
93

6
51
57
129
111
159
87
141
177
123
```
