public class dayFour
{
    private string[] inputFile;

    private ElfAssignment elfOne;
    private ElfAssignment elfTwo;
    public dayFour()
    {
        inputFile = File.ReadAllLines("./days/dayFourInput.txt");
    }

    private void Setup(string line)
    {
        var inputs = line.Split(',');
        elfOne = new ElfAssignment(inputs[0]);
        elfTwo = new ElfAssignment(inputs[1]);
    }

    public void PartOne()
    {
        var numberOfPairs = 0;
        foreach (var line in inputFile)
        {
            Setup(line);

            if (isWithin(elfOne, elfTwo))
            {
                numberOfPairs++;
                continue;
            }
            else if (isWithin(elfTwo, elfOne))
            {
                numberOfPairs++;
                continue;
            }
        }

        Console.WriteLine(numberOfPairs.ToString());
    }

    public void PartTwo()
    {
        var numberOfOverlap = 0;

        foreach (var line in inputFile)
        {
            Setup(line);

            if (elfOne.Overlaps(elfTwo))
            {
                numberOfOverlap++;
            }
        }

        Console.WriteLine(numberOfOverlap.ToString());
    }

    private bool isWithin(ElfAssignment toCheck, ElfAssignment against)
    {
        return toCheck.Min <= against.Min && toCheck.Max <= against.Max;
    }

    private class ElfAssignment
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public bool Overlaps(ElfAssignment comparison) => Min <= comparison.Max && Max >= comparison.Min;

        public ElfAssignment(string range)
        {

            var elfOneRange = range.Split('-');

            int[] ints = Array.ConvertAll(elfOneRange, int.Parse);

            Min = ints.Min();
            Max = ints.Max();
        }
    }
}