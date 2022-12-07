public class daySix
{
    private string[] inputFile;
    private string packet;
    public daySix()
    {
        inputFile = File.ReadAllLines("./days/daySixInputFile.txt");
        packet = inputFile[0];
    }

    private void CharsToParseForUniqueString(int numberOfUniqueChars)
    {
        var pointer = numberOfUniqueChars;

        while ((pointer-numberOfUniqueChars) <= packet.Length)
        {
            var range = new Range((pointer-numberOfUniqueChars), pointer);
            var chars = packet.Take(range);

            if (chars.Distinct().Count() != numberOfUniqueChars)
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

    public void PartOne()
    {
        CharsToParseForUniqueString(4);
    }

    public void PartTwo()
    {
        CharsToParseForUniqueString(14);
    }
}