namespace AdventOfCode2025.Day3;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var batteryBanks = File.ReadAllLines(filePath);

        var joltages = new List<int>();

        foreach (var bank in batteryBanks)
        {
            var batteries = bank.ToCharArray();

            var highestJoltage = 0;

            for (var i = 0; i < batteries.Length; i++)
            {
                for (var j = i+1; j < batteries.Length; j++)
                {
                    var currentJoltage = int.Parse($"{batteries[i]}{batteries[j]}");
                    
                    if(currentJoltage > highestJoltage)
                        highestJoltage = currentJoltage;
                }
            }
            
            joltages.Add(highestJoltage);
        }

        Console.WriteLine($"Sum of highest joltages: {joltages.Sum()}");
    }
}