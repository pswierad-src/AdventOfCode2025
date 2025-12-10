namespace AdventOfCode2025.Day9;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var points = File.ReadAllLines(filePath).Select(p =>
        {
            var coords = p.Split(',');
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }).ToArray();

        var shape = new Shape(points);
        long maxArea = 0;

        for (var i = 0; i < points.Length; i++)
        {
            var p1 = points[i];

            for (var j = i + 1; j < points.Length; j++)
            {
                var p2 = points[j];

                var rectangle = new Shape([
                    new Point(Math.Min(p1.X, p2.X) + 0.5, Math.Min(p1.Y, p2.Y) + 0.5),
                    new Point(Math.Max(p1.X, p2.X) - 0.5, Math.Min(p1.Y, p2.Y) + 0.5),
                    new Point(Math.Max(p1.X, p2.X) - 0.5, Math.Max(p1.Y, p2.Y) - 0.5),
                    new Point(Math.Min(p1.X, p2.X) + 0.5, Math.Max(p1.Y, p2.Y) - 0.5)
                ]);

                if (rectangle.Edges.Any(edge => shape.Intersecting(edge)))
                    continue;

                var area = p1.GetRectangleArea(p2);
                maxArea = Math.Max(maxArea, area);
            }
        }

        Console.WriteLine($"Part 2: {maxArea}");
    }
}