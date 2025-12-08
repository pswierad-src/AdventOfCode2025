namespace AdventOfCode2025.Day7;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var grid = File.ReadAllLines(filePath);

        var timesSplit = 0;
        var beams = new Queue<(int y, int x)>();
        beams.Enqueue((0, grid[0].IndexOf('S')));

        while (beams.Count > 0)
        {
            var (y, x) = beams.Dequeue();
            
            if(y+1 >= grid.Length)
                continue;

            switch (grid[y+1][x])
            {
                case '.':
                    if (!beams.Contains((y + 1, x)))
                        beams.Enqueue((y+1, x));
                    break;
                case '^':
                    timesSplit++;
                    if (x - 1 >= 0 && grid[y + 1][x - 1] == '.' && !beams.Contains((y + 1, x - 1)))
                    {
                        beams.Enqueue((y+1, x-1));
                    }
                    if (x + 1 < grid[0].Length && grid[y + 1][x + 1] == '.' && !beams.Contains((y + 1, x + 1)))
                    {
                        beams.Enqueue((y+1, x+1));
                    }
                    break;
            }
        }
        
        Console.WriteLine($"Beam split {timesSplit} times.");
    }
}
