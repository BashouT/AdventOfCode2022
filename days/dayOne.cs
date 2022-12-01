public class dayOne
{
    private readonly string[] inputFile;
    private readonly List<int> totals;
    public dayOne()
    {
        inputFile = File.ReadAllLines("./days/dayOneInput.txt");
        totals = new List<int>();
    }

    public void parseElves()
    {
        var current = 0;
        foreach (var line in inputFile)
        {
            if (string.IsNullOrEmpty(line))            
            {
                totals.Add(current);
                current = 0;
                continue;
            }
            current += int.Parse(line);
        }

        var sortedTotals = totals.OrderByDescending(t => t);

        Console.WriteLine(sortedTotals.Take(3).Sum().ToString());
    }
}