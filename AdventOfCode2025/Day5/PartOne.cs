namespace AdventOfCode2025.Day5;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var input = File.ReadAllText(filePath).Split(Environment.NewLine + Environment.NewLine);

        var ranges = input[0].Split(Environment.NewLine);
        var ingredients = input[1].Split(Environment.NewLine).Select(long.Parse).ToList();
        
        var freshRanges = BuildFreshRanges(ranges);

        var freshIds = 0;

        foreach (var ingredient in ingredients)
        {
            if (freshRanges.Any(r => r.start <= ingredient && ingredient <= r.end))
                freshIds++;
        }

        Console.WriteLine($"There are {freshIds} fresh ingredients.");
    }

    private static List<(long start, long end)> BuildFreshRanges(string[] ranges)
        => ranges.Select(range => range.Split('-')
                .Select(long.Parse)
                .ToArray())
            .Select(boundaries => (boundaries[0], boundaries[1]))
            .ToList();
}