namespace AdventOfCode2025.Day10;

public class PartOne : IPartOne
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

        var totalPressCount = 0;

        foreach (var machine in machines)
        {
            for (var pressCount = 0; pressCount <= machine.Buttons.Count; pressCount++)
            {
                if (!Solve(machine, pressCount, 0, 0, new bool[machine.States.Count])) 
                    continue;
                totalPressCount += pressCount;
                break;
            }
        }

        Console.WriteLine($"Total press count {totalPressCount}");
    }
    
    private static bool Solve(Machine machine, int target, int start, int depth, bool[] state)
    {
        if (depth == target)
            return state.SequenceEqual(machine.States);

        for (var i = start; i <= machine.Buttons.Count - (target - depth); i++)
        {
            foreach (var idx in machine.Buttons[i].Where(idx => idx < state.Length))
            {
                state[idx] = !state[idx];
            }

            if (Solve(machine, target, i + 1, depth + 1, state))
                return true;
            
            foreach (var idx in machine.Buttons[i].Where(idx => idx < state.Length))
            {
                state[idx] = !state[idx];
            }
        }
        return false;
    }
}
