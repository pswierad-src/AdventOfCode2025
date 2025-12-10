namespace AdventOfCode2025.Day9;

public class Edge
{
    public Point P1 { get; set; }
    public Point P2 { get; set; }
    public bool IsHorizontal { get; set; }

    public Edge(Point p1, Point p2)
    {
        IsHorizontal = p1.Y == p2.Y;
        if (IsHorizontal)
        {
            P1 = p1.X < p2.X ? p1 : p2;
            P2 = p1.X < p2.X ? p2 : p1;
        }
        else
        {
            P1 = p1.Y < p2.Y ? p1 : p2;
            P2 = p1.Y < p2.Y ? p2 : p1;
        }
    }

    public bool Intersecting(Edge other)
    {
        if (IsHorizontal == other.IsHorizontal)
        {
            return false;
        }

        var horizontal = IsHorizontal ? this : other;
        var vertical = IsHorizontal ? other : this;

        return vertical.P1.X > horizontal.P1.X && vertical.P1.X < horizontal.P2.X &&
               horizontal.P1.Y > vertical.P1.Y && horizontal.P1.Y < vertical.P2.Y;
             
    }
}