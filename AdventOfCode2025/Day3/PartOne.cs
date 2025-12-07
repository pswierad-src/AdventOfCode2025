namespace AdventOfCode2025.Day3;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var rolls = 0;
        var grid = File.ReadAllLines(filePath).Select(l => l.ToCharArray()).ToArray();

        for (var y = 0; y < grid.Length; y++)
        {
            for (var x = 0; x < grid[0].Length; x++)
            {
                if(grid[y][x] == '.')
                    continue;

                var neighbours = GetNeighbours(grid, x, y);
                
                if(neighbours.Count(n => n == '@') < 4)
                    rolls++;
                    
            }
        }

        Console.WriteLine($"Rolls: {rolls}");
    }

    private static char[] GetNeighbours(char[][] grid, int x, int y)
    {
        return
        [
            grid.ElementAtOrDefault(y - 1)?.ElementAtOrDefault(x) ?? '.', //up
            grid.ElementAtOrDefault(y - 1)?.ElementAtOrDefault(x + 1) ?? '.', // up-right
            grid.ElementAtOrDefault(y)?.ElementAtOrDefault(x + 1) ?? '.', // right
            grid.ElementAtOrDefault(y + 1)?.ElementAtOrDefault(x + 1) ?? '.', // down-right
            grid.ElementAtOrDefault(y + 1)?.ElementAtOrDefault(x) ?? '.', // down
            grid.ElementAtOrDefault(y + 1)?.ElementAtOrDefault(x - 1) ?? '.', // down-left
            grid.ElementAtOrDefault(y)?.ElementAtOrDefault(x - 1) ?? '.', // left
            grid.ElementAtOrDefault(y - 1)?.ElementAtOrDefault(x - 1) ?? '.', // up-left
        ];
    }
}