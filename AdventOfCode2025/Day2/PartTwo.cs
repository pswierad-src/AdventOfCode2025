namespace AdventOfCode2025.Day2;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var lines = File.ReadAllText(filePath);

        var inputRanges = lines.Split(',')
            .Select(r => r.Split('-'))
            .Select(r => (long.Parse(r[0]), long.Parse(r[1])))
            .ToList();
        
        var invalidIds = new List<long>();

        foreach (var range in inputRanges)
        {
            for (var id = range.Item1; id <= range.Item2; id++)
            {
                var number = id.ToString();
                var length = number.Length;
                
                for (var patternLength = 1; patternLength <= length / 2; patternLength++)
                {
                    if (length % patternLength != 0) 
                        continue;
                    
                    var pattern = number[..patternLength];

                    if (!number.Where((t, i) => t != pattern[i % pattern.Length]).Any())
                    {
                        invalidIds.Add(id);
                        break;
                    }
                }
            }
        }
        
        Console.WriteLine($"Sum of invalid IDs: {invalidIds.Sum()}");
    }
}