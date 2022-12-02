public class dayTwo
{
    private readonly string[] inputFile;

    private Dictionary<string, int> choiceMapDictionary = new Dictionary<string, int>();

    public dayTwo()
    {
        inputFile = File.ReadAllLines("./days/dayTwoInput.txt");

        choiceMapDictionary.Add("A X", 0 + 3);
        choiceMapDictionary.Add("A Y", 3 + 1);
        choiceMapDictionary.Add("A Z", 6 + 2);

        choiceMapDictionary.Add("B X", 0 + 1);
        choiceMapDictionary.Add("B Y", 3 + 2);
        choiceMapDictionary.Add("B Z", 6 + 3);

        choiceMapDictionary.Add("C X", 0 + 2);
        choiceMapDictionary.Add("C Y", 3 + 3);
        choiceMapDictionary.Add("C Z", 6 + 1);
    }

    public void CalculateScore()
    {
        var totalScore = 0;
        foreach (var line in inputFile)
        {
           var score = choiceMapDictionary.TryGetValue(line, out int gameScore);
           totalScore += gameScore;
        }

        Console.WriteLine(totalScore);
    }
}
