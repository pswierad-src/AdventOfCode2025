namespace AdventOfCode2025.Day7;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var grid = File.ReadAllLines(filePath);

        var possibleBeams = 0L;
        var startingPoint = (0, grid[0].IndexOf('S'));

        var beams = new Queue<(int y, int x)>();
        beams.Enqueue(startingPoint);
        
        var b = new Dictionary<(int y, int x), long>
        {
            [startingPoint] = 1
        };

        while (beams.Count > 0)
        {
            var (y, x) = beams.Dequeue();
            var count = b[(y, x)];
            
            if (y + 1 >= grid.Length)
            {
                possibleBeams += count;
                continue;
            }

            switch (grid[y + 1][x])
            {
                case '.': 
                    AddBeam((y + 1, x), count); 
                    break;
                case '^':
                    if (IsWithinGridWidth(x-1) && IsEmptySpace(y+1, x-1)) 
                        AddBeam((y + 1, x - 1), count);
                    if (IsWithinGridWidth(x+1) && IsEmptySpace(y+1, x+1)) 
                        AddBeam((y + 1, x + 1), count);
                    break;
            }
        }

        Console.WriteLine($"There are: {possibleBeams} possible beams.");

        return;
        
        bool IsWithinGridWidth(int x) => x >= 0 && x < grid[0].Length;
        
        bool IsEmptySpace(int y, int x) => grid[y][x] == '.';
        
        void AddBeam((int, int) p, long count)
        {
            if (!b.TryAdd(p, count)) 
                b[p] += count;

            if (!beams.Contains(p)) 
                beams.Enqueue(p);
        }
    }
}