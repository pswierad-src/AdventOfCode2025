namespace AdventOfCode2025.Day11;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var input = !filePath.Contains("test")
            ? File.ReadAllLines(filePath)
            : """
              svr: aaa bbb
              aaa: fft
              fft: ccc
              bbb: tty
              tty: ccc
              ccc: ddd eee
              ddd: hub
              hub: fff
              eee: dac
              dac: fff
              fff: ggg hhh
              ggg: out
              hhh: out
              """.Split(Environment.NewLine);
        
        var devices = input
            .Select(line => line.Split(": "))
            .ToDictionary(
                parts => parts[0], 
                parts => parts[1].Split(' ').ToArray()
            );

        var paths = new Dictionary<(string node, bool visitedDac, bool visitedFft), long>();
        
        var result = CheckNextStep(("svr", false, false));
        
        Console.WriteLine($"Total paths from svr to out that passes dac, fft: {result}");

        return;
        
        long CheckNextStep((string node, bool visitedDac, bool visitedFft) state)
        {
            if (state.node == "out")
                return state.visitedDac && state.visitedFft ? 1 : 0;
            
            if (paths.TryGetValue(state, out var step))
                return step;
            
            long totalPaths = 0;
            
            foreach (var neighbor in devices[state.node])
            {
                var nextState = (
                    node: neighbor,
                    visitedDac: state.visitedDac || neighbor == "dac",
                    visitedFft: state.visitedFft || neighbor == "fft"
                );
        
                totalPaths += CheckNextStep(nextState);
            }
            
            paths[state] = totalPaths;
            return totalPaths;
        }
    }
}