# Find Random Numbers Such That
This console app is an easily extensible generator for random numbers that satisfy given conditions.

## Usage
`Conditions.cs`
1. Create a method for a condition you want to satisfy, and a delegate containing that method. Example:
```csharp
private static bool CheckIfDivisibleBy(int inputNumber, int divisor)
{
    return inputNumber % divisor == 0;
}
public static readonly Func<int, int, bool> IsDivBy = CheckIfDivisibleBy;
```

`Program.cs`
1. Create `NumberGenerator` class instance

```csharp
var numberGenerator = new NumberGenerator();
```

2. Add conditions to the `NumberGenerator` instance. Example:

```csharp
numberGenerator.AddCondition(Conditions.IsHigherThan, 3);
numberGenerator.AddCondition(Conditions.IsLowerThan, 200);
numberGenerator.AddCondition(Conditions.IsDivBy, 3);
```

3. Generate two arrays containing n numbers, first with duplicate numbers, second without. Example with n=10:

```csharp
var numArrayWithDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: true);
var numArrayWithoutDuplicates = numberGenerator.GenerateNumbersArray(10, allowDuplicates: false);
```

Printed output:
```
51
15
51
33
129
57
123
15
159
15

33
39
159
141
69
9
51
57
123
129
```