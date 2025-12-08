namespace AdventOfCode2025.Day8;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var junctionBoxes = File.ReadAllLines(filePath)
            .Select(line => line.Split(','))
            .Select(jb => new JunctionBox(int.Parse(jb[0]), int.Parse(jb[1]), int.Parse(jb[2])))
            .ToList();

        var distances = new List<(JunctionBox from, JunctionBox to, double distance)>();

        for (var i = 0; i < junctionBoxes.Count; i++)
        {
            for (var j = i+1; j < junctionBoxes.Count; j++)
            {
                var distance = junctionBoxes[i].DistanceTo(junctionBoxes[j]);
                distances.Add((junctionBoxes[i], junctionBoxes[j], distance));
            }
        }

        distances = distances.OrderBy(d => d.distance).ToList();

        var circuits = junctionBoxes.Select(junctionBox => (HashSet<JunctionBox>) [junctionBox]).ToList();

        var x = 0;

        while (true)
        {
            x++;
            
            var from = distances[x-1].from;
            var to = distances[x-1].to;
            
            var circuit1 = circuits.First(c => c.Contains(from));
            var circuit2 = circuits.First(c => c.Contains(to));

            if (circuit1 != circuit2)
            {
                circuit1.UnionWith(circuit2);
                circuits.Remove(circuit2);
                circuits = [..circuits.OrderByDescending(c => c.Count)];
            }

            if (!circuits.TrueForAll(c => c.Count > 1)) 
                continue;
            
            Console.WriteLine($"Biggest circuit after {x} iterations: {circuits[0].Count}");
            Console.WriteLine($"Multiplied X of last 2 junction boxes: {from.X * to.X}");
            break;
        }
    }
}