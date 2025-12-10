namespace AdventOfCode2025.Day9;
 
 public class Shape
 {
     public Point[] Points { get; }
     public Edge[] Edges { get; }
 
     public Shape(Point[] points)
     {
         Points = points;
         Edges = new Edge[points.Length];
         for (var i = 0; i < points.Length; i++)
         {
             var next = points[(i + 1) % points.Length];
             Edges[i] = new Edge(points[i], next);
         }
     }
 
     public bool Intersecting(Edge edge)
     {
         return Edges.Any(e => e.Intersecting(edge));
     }
 }