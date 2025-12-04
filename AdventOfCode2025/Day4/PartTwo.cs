namespace AdventOfCode2025.Day4;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var previousRolls = 0;
        var rolls = 0;
        var grid = File.ReadAllLines(filePath).Select(l => l.ToCharArray()).ToArray();

        while (true)
        {
            previousRolls = rolls;
            
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[0].Length; x++)
                {
                    if(grid[y][x] == '.' || grid[y][x] == 'x')
                        continue;

                    var neighbours = GetNeighbours(grid, x, y);

                    if (neighbours.Count(n => n == '@') < 4)
                    {
                        grid[y][x] = 'x';
                        rolls++;
                    }
                }
            }

            if (rolls == previousRolls)
                break;
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