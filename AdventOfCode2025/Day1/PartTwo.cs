namespace AdventOfCode2025.Day1;

public class PartTwo : IPartTwo
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
            var wasZero = startingPoint == 0;

            switch (direction)
            {
                case 'R': break;
                case 'L': steps = -steps; break;
            }

            var fullRotations = Math.Abs(steps / 100);
            timesAtZero += fullRotations;

            if (steps > 0)
                startingPoint += steps - fullRotations * 100;
            else
                startingPoint += steps + fullRotations * 100;

            if (!wasZero && (startingPoint > 99 || startingPoint <= 0))
            {
                timesAtZero++;
            }

            startingPoint = (startingPoint + 100) % 100;
        }
        
        Console.WriteLine($"Total times at zero: {timesAtZero}");
    }
}