namespace AdventOfCode2025.Day10;

public class Machine(List<HashSet<int>> buttons, List<bool> states, List<int> joltages)
{
    public List<HashSet<int>> Buttons { get; set; } = buttons;
    public List<bool> States { get; set; } = states;
    public List<int> Joltages { get; set; } = joltages;
}