using AdventOfCode2025;

while (true)
{
    Console.WriteLine("Advent of Code 2025");
    Console.WriteLine("=====================");
    Console.WriteLine("Select day to run. 0 for exit");
    
    if(!int.TryParse(Console.ReadLine(), out var day) || day == 0)
    {
        return;
    }
    
    try
    {
        var (partOne, partTwo) = DayFactory.GetForDay(day);
        
        Console.WriteLine(Environment.NewLine + "Part one solution:");
        partOne.Execute(@$"Day{day}\test.txt");
        partOne.Execute(@$"Day{day}\input.txt");
        
        Console.WriteLine(Environment.NewLine + "Part two solution:");
        partTwo.Execute(@$"Day{day}\test.txt");
        partTwo.Execute(@$"Day{day}\input.txt");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
    }

    Console.ReadLine();
    Console.Clear();
}