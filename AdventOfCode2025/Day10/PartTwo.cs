using Microsoft.Z3;

namespace AdventOfCode2025.Day10;

public class PartTwo : IPartTwo
{
    public void Execute(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        var machines = new List<Machine>();

        foreach (var line in input.Where(l => !string.IsNullOrWhiteSpace(l)))
        {
            var parts = line.Split(' ');
            
            var states = parts[0][1..^1].Select(c => c == '#').ToList();
            
            var buttons = parts.Skip(1)
                .TakeWhile(p => p.StartsWith('('))
                .Select(p => p[1..^1].Split(',').Select(int.Parse).ToHashSet())
                .ToList();
            
            var joltages = (parts.Skip(1 + buttons.Count)
                .FirstOrDefault(p => p.StartsWith('{'))?
                [1..^1]!).Split(',').Select(int.Parse).ToList() ?? [];

            machines.Add(new Machine(buttons, states, joltages));
        }

        long totalPressCount = 0;

        foreach (var machine in machines)
        {
            using var context = new Context();
            using var optimize = context.MkOptimize();
            
            var presses = Enumerable.Range(0, machine.Buttons.Count)
                .Select(i => context.MkIntConst($"p{i}"))
                .ToArray();
        
            foreach (var press in presses)
                optimize.Add(context.MkGe(press, context.MkInt(0)));
        
            for (var i = 0; i < machine.Joltages.Count; i++)
            {
                var affecting = presses.Where((_, j) => machine.Buttons[j].Contains(i)).ToArray();
                if (affecting.Length <= 0) 
                    continue;
                        
                var sum = affecting.Length == 1 
                    ? affecting[0] 
                    : context.MkAdd(affecting);
                        
                optimize.Add(context.MkEq(sum, context.MkInt(machine.Joltages[i])));
            }
        
            optimize.MkMinimize(presses.Length == 1 ? presses[0] : context.MkAdd(presses));
            optimize.Check();
        
            var model = optimize.Model;
            totalPressCount += presses.Sum(p => ((IntNum)model.Evaluate(p, true)).Int64);
        }

        Console.WriteLine($"Total press count {totalPressCount}");
    }
}