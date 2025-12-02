using System.Reflection;

namespace AdventOfCode2025;

public static class DayFactory
{
    public static (IPartOne, IPartTwo) GetForDay(int day)
    {
        var partOne = Create<IPartOne>(day);
        var partTwo = Create<IPartTwo>(day);
        return (partOne, partTwo);
    }
    
    private static T Create<T>(int catalogue) where T : class
    {
        var namespaceName = $"AdventOfCode2025.Day{catalogue.ToString().ToUpper()}";
        var className = typeof(T).Name[1..];
        var fullTypeName = $"{namespaceName}.{className}";

        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.FullName == fullTypeName);

        if (type == null)
        {
            throw new ArgumentException(
                $"Could not find {className} in {namespaceName}. " +
                $"Make sure catalogue '{catalogue}' exists."
            );
        }

        return Activator.CreateInstance(type) as T 
               ?? throw new InvalidOperationException(
                   $"Failed to create instance of {fullTypeName}"
               );
    }
}

public interface IPartOne
{
    void Execute(string filePath);
}

public interface IPartTwo
{
    void Execute(string filePath);
}
