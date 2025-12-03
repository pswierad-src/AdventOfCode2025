namespace AdventOfCode2025.Day3;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var batteryBanks = File.ReadAllLines(filePath);

        var joltages = new List<long>();

        foreach (var bank in batteryBanks)
        {
            var batteries = bank.Select(c => int.Parse(c.ToString())).ToArray();
            var maxBatteries = new int[12];
            long bankJoltage = 0;
            for (var i = maxBatteries.Length - 1; i >= 0; i--)
            {
                var startAt = i == maxBatteries.Length - 1 ? 0 : maxBatteries[i + 1] + 1;
                maxBatteries[i] = startAt;
                for (var cellToCheck = startAt; cellToCheck < batteries.Length - i; cellToCheck++)
                {
                    if (batteries[cellToCheck] > batteries[maxBatteries[i]])
                        maxBatteries[i] = cellToCheck;
                }
                
                bankJoltage += batteries[maxBatteries[i]] * (long)Math.Pow(10, i);
            }
            
            joltages.Add(bankJoltage);
        }

        Console.WriteLine($"Sum of highest joltages: {joltages.Sum()}");
    }
}