namespace AdventOfCode2025.Day2;

public class PartOne : IPartOne
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
                
                if(length % 2 != 0)
                    continue;
                
                var firstHalf = number[..(length / 2)];
                var secondHalf = number.Substring(length / 2, length / 2);
                
                if(firstHalf == secondHalf)
                    invalidIds.Add(id);
            }
            
        }
        
        Console.WriteLine($"Sum of invalid IDs: {invalidIds.Sum()}");
    }
}