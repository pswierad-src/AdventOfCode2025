namespace AdventOfCode2025.Day6;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        var digits = input.Select(line => line.ToList()).ToList();
        var totals = new List<long>();

        while (digits[^1].Count > 0)
        {
            var endOfColumn = false;
            var operation = ' ';
            
            var rotatedNumbers = new List<string>();
            
            while (!endOfColumn)
            {
                var currentNumber = string.Empty;
                
                foreach (var line in digits)
                {
                    var lastOper = line[^1];
                    line.RemoveAt(line.Count - 1);

                    if (lastOper is '+' or '*')
                    {
                        endOfColumn = true;
                        operation = lastOper;
                        break;
                    }

                    currentNumber += lastOper;
                }

                rotatedNumbers.Add(currentNumber);
            }

            rotatedNumbers = [.. rotatedNumbers.Where(n => !string.IsNullOrWhiteSpace(n))];

            var subTotal = operation switch
            {
                '*' => rotatedNumbers.Select(n => n.Trim().TrimEnd()).Select(long.Parse).Aggregate(1L, (acc, x) => acc * x),
                '+' => rotatedNumbers.Select(n => n.Trim().TrimEnd()).Select(long.Parse).Sum()
            };

            totals.Add(subTotal);
        }

        Console.WriteLine($"Grand total is {totals.Sum()}");
    }
}