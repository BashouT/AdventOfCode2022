public class dayThree
{
    private string[] inputFile;

    public dayThree()
    {
        inputFile = File.ReadAllLines("./days/dayThreeInput.txt");
    }

    public void PartOne()
    {
        int sum = 0;

        foreach (var line in inputFile)
        {
            var first = line.Substring(0, (line.Length / 2));
            var second = line.Substring((line.Length / 2), (line.Length / 2));

            var intersect = first.Intersect(second);

            var repeatedChar = intersect.First();
            
            var priorityValue = GetPriorityValue(repeatedChar);
            sum += priorityValue;
        }

        Console.WriteLine(sum);
    }

    public void PartTwo()
    {
        var badgeSum = inputFile.Chunk(3).Sum(group => group[0].Intersect(group[1]).Intersect(group[2]).Sum(g => GetPriorityValue(g)));
        Console.WriteLine(badgeSum);
    }

    private static int GetPriorityValue(char character)
    {
        var priorityValue = 0;

        if (char.IsUpper(character))
        {
            priorityValue = (int)character - 38;
        }
        else
        {
            priorityValue = (int)character - 96;
        }

        return priorityValue;
    }
}