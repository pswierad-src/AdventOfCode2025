namespace AdventOfCode2025.Day9;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var points = File.ReadAllLines(filePath).Select(p =>
        {
            var coords = p.Split(',');
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }).ToList();
        
        long maxArea = 0;
        
        for (var i = 0; i < points.Count; i++)
        {
            for (var j = i+1; j < points.Count; j++)
            {
                var area = points[i].GetRectangleArea(points[j]);
                
                if(area > maxArea)
                    maxArea = area;
            }
        }
        
        Console.WriteLine($"Area of the largest rectangle: {maxArea}");
    }
}
