namespace AdventOfCode2025.Day9;

public class Point(double x, double y)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    

    public double DistanceTo(Point other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        
        return Math.Sqrt(dx * dx + dy * dy);
    }
    
    public long GetRectangleArea(Point other)
    {
        var width = (long)Math.Abs(X - other.X) + 1;
        var height = (long)Math.Abs(Y - other.Y) + 1;
        return width * height;
    }
}