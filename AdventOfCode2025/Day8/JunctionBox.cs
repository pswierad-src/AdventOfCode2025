namespace AdventOfCode2025.Day8;

public class JunctionBox(int x, int y, int z)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Z { get; set; } = z;

    public double DistanceTo(JunctionBox other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        double dz = Z - other.Z;
        
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}