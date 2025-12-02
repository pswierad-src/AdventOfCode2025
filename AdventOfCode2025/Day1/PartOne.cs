namespace AdventOfCode2025.Day1;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var startingPoint = 50;
        var timesAtZero = 0;

        foreach (var rotation in lines)
        {
            var direction = rotation[0];
            var steps = int.Parse(rotation[1..]);

            switch (direction)
            {
                case 'R': 
                    startingPoint += steps;
                    if (startingPoint >= 100)
                        startingPoint = (startingPoint % 100);
                    break;
                case 'L': 
                    startingPoint -= steps;
                    if(startingPoint < 0)
                        startingPoint = (startingPoint % 100);
                    break;
            }
            
            if (startingPoint == 0)
                timesAtZero++;
        }
        
        Console.WriteLine($"Total times at zero: {timesAtZero}");
    }
}