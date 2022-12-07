public class daySix
{
    private string[] inputFile;
    public daySix()
    {
        inputFile = File.ReadAllLines("./days/daySixInputFile.txt");
    }

    public void PartOne()
    {
        var line = inputFile[0];
        var pointer = 4;
        while ((pointer-4) <= line.Length)
        {
            var range = new Range((pointer-4), pointer);
            var chars = line.Take(range);

            if (chars.Distinct().Count() != 4)
            {
                pointer += 1;
                continue;
            }
            else
            {
                Console.WriteLine(pointer.ToString());
                break;
            }
        }
    }

    public void PartTwo()
    {
        var line = inputFile[0];
        var pointer = 14;
        while ((pointer-14) <= line.Length)
        {
            var range = new Range((pointer-14), pointer);
            var chars = line.Take(range);

            if (chars.Distinct().Count() != 14)
            {
                pointer += 1;
                continue;
            }
            else
            {
                Console.WriteLine(pointer.ToString());
                break;
            }
        }
    }
}