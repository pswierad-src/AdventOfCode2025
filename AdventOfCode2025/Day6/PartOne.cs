using System.Globalization;

namespace AdventOfCode2025.Day6;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var input = File.ReadAllLines(filePath);

        var numbers = new List<List<long>>();

        var operations = input[^1].Split(' ')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToList();

        for (var i = 0; i < input.Length - 1; i++)
        {
            var n = input[i].Split(' ')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(long.Parse)
                .ToList();
            
            numbers.Add(n);
        }

        var totals = new List<long>();

        for (var i = 0; i < operations.Count; i++)
        {
            var elements = numbers.Select(n => n[i]).ToList();

            var subTotal = operations[i] switch
            {
                "*" => elements.Aggregate(1L, (acc, x) => acc * x),
                "+" => elements.Sum(),
            };
            
            totals.Add(subTotal);
        }

        Console.WriteLine($"Grand total is {totals.Sum()}");
    }
}
