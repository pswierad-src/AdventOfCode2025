namespace AdventOfCode2025.Day11;

public class PartOne : IPartOne
{
    public void Execute(string filePath)
    {
        var input = !filePath.Contains("test")
            ? File.ReadAllLines(filePath)
            : """
              aaa: you hhh
              you: bbb ccc
              bbb: ddd eee
              ccc: ddd eee fff
              ddd: ggg
              eee: out
              fff: out
              ggg: out
              hhh: ccc fff iii
              iii: out
              """.Split(Environment.NewLine);
        
        var devices = input
            .Select(rawDevice => rawDevice.Split(": "))
            .Select(dev => new Device(dev[0], dev[1].Split(' ')))
            .ToList();

        var start = devices.FirstOrDefault(d => d.Name == "you");
        
        if(start is null)
            return;

        var totalPaths = 0;
        CheckNextStep(start);

        Console.WriteLine($"Total paths: {totalPaths}");
        
        return;
        
        void CheckNextStep(Device currentDevice)
        {
            if (currentDevice.Outputs.Contains("out"))
            {
                totalPaths++;
            }
        
            var nextDevices = devices.Where(d => currentDevice.Outputs.Contains(d.Name));

            foreach (var device in nextDevices)
            {
                CheckNextStep(device);
            }
        }
    }
}
