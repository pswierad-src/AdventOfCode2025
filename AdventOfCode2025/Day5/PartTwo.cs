namespace AdventOfCode2025.Day5;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var input = File.ReadAllText(filePath).Split(Environment.NewLine + Environment.NewLine);

        var ranges = input[0].Split(Environment.NewLine);
        
        var freshRanges = BuildFreshRanges(ranges);
        var merged = MergeRanges(freshRanges);

        var freshIds = merged.Sum(m => (m.end - m.start + 1));

        Console.WriteLine($"Ids considered fresh cound: {freshIds}");
    }

    private static List<(long start, long end)> BuildFreshRanges(string[] ranges)
        => ranges.Select(range => range.Split('-')
                .Select(long.Parse)
                .ToArray())
            .Select(boundaries => (boundaries[0], boundaries[1]))
            .ToList();

    private static List<(long start, long end)> MergeRanges(List<(long start, long end)> ranges)
    {
        var sorted = ranges.OrderBy(r => r.start).ToList();
        var merged = new List<(long start, long end)>();
        var current = sorted[0];
        
        for (var i = 1; i < sorted.Count; i++)
        {
            var next = sorted[i];
            
            if (next.start <= current.end)
            {
                current.end = Math.Max(current.end, next.end);
            }
            else
            {
                merged.Add(current);
                current = next;
            }
        }
        merged.Add(current);
        
        return merged;
    }
}