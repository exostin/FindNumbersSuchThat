# Find Random Numbers Such That
This console app is an easily extensible generator for random numbers that satisfy given conditions.

## Usage
`Conditions.cs`
1. Create a method for a condition you want to satisfy, and a delegate containing that method. Example:
```csharp
private static bool DivisibleBy(int inputNumber, int divisor)
{
    return inputNumber % divisor == 0;
}
public static readonly Func<int, int, bool> IsDivBy = DivisibleBy;
```

`Program.cs`
1. Create `NumberGenerator` class instance

```csharp
var numberGenerator = new NumberGenerator();
```

2. Add conditions to the `NumberGenerator` instance

```csharp
numberGenerator.AddCondition(Conditions.IsHigherThan, 3);
numberGenerator.AddCondition(Conditions.IsLowerThan, 200);
numberGenerator.AddCondition(Conditions.IsDivBy, 3);
```

3. Generate the numbers

```csharp
var numArray = numberGenerator.GenerateNumbersArray(15);
```