using System.Text.RegularExpressions;

public class dayFive
{
    private string[] inputFile;

    private CraneFacility _craneFacility;
    private IEnumerable<string> _instructions;

    public dayFive()
    {
        inputFile = File.ReadAllLines("./days/dayFiveInput.txt");
        _craneFacility = new CraneFacility();
        CreateTowers();
        _instructions = inputFile.Skip(10);
    }

    private void CreateTowers()
    {
        var cratesLines = inputFile.Take(9).ToArray().Reverse();
        var crateRows = cratesLines.First();

        for (int i = 1; i < 10; i++)
        {
            var position = Convert.ToChar(i.ToString());
            var index = crateRows.IndexOf(position);

            var crates = new Stack<string>();
            foreach (var line in cratesLines.Skip(1))
            {
                var crateId = line[index];
                if (char.IsWhiteSpace(crateId))
                {
                    continue;
                }
                crates.Push(crateId.ToString());
            } 
            
            _craneFacility.CreateTower(i, crates);
        }
    }

    public void PartOne()
    {
        foreach (var line in _instructions)
        {
            var instructionParts = Regex.Matches(line, @"\d+")
            .Select(m => m.Value)
            .ToArray();

            var numberToMove = int.Parse(instructionParts[0]);
            var from = int.Parse(instructionParts[1]);
            var to = int.Parse(instructionParts[2]);

            for (var i = 1; i <= numberToMove; ++i)
            {
                _craneFacility.MoveCrate(from, to);
            }
        }

        var report = _craneFacility.ReportTowers(); 
        Console.WriteLine(report);
    }

    public void PartTwo()
    {
         foreach (var line in _instructions)
        {
            var instructionParts = Regex.Matches(line, @"\d+")
            .Select(m => m.Value)
            .ToArray();

            var numberToMove = int.Parse(instructionParts[0]);
            var from = int.Parse(instructionParts[1]);
            var to = int.Parse(instructionParts[2]);

                _craneFacility.MoveCrates(from, to, numberToMove);
        }

        var report = _craneFacility.ReportTowers(); 
        Console.WriteLine(report);
    }

    private class CraneFacility
    {
        private List<Tower> _towers {get; set;}

        public CraneFacility()
        {
           _towers = new List<Tower>(); 
        }

        public string ReportTowers()
        {
            var towerReport = "";
            foreach (var tower in _towers)
            {
                var topCrate = tower.ReportCrate();
                towerReport = towerReport + topCrate;
            }

            return towerReport;
        }

        public void CreateTower(int id, Stack<string> startingCrates)
        {
            _towers.Add(new Tower(startingCrates, id));
        }

        public void MoveCrate(int startingTower, int finalTower)
        {
            var liftedCrate = _towers.First(t => t.Id == startingTower).RemoveCrate();
            _towers.First(t => t.Id == finalTower).AddCrate(liftedCrate);
        }

        public void MoveCrates(int startingTower, int finalTower, int numberToMove)
        {
            var liftedCrates = _towers.First(t => t.Id == startingTower).RemoveCrates(numberToMove);
            _towers.First(t => t.Id == finalTower).AddCrates(liftedCrates);
        }
    }

    private class Tower
    {
        Stack<string> _crates;
        public int Id;

        public Tower(Stack<string> startingCrates, int id)
        {
           _crates = startingCrates; 
           Id = id;
        }

        public string RemoveCrate()
        {
            return _crates.Pop();
        }

        public string RemoveCrates(int numberToMove)
        {
            var movedCrates = "";
            for (var moved = 1; moved <= numberToMove; ++moved)
            {
               movedCrates = movedCrates + _crates.Pop(); 
            }

            return movedCrates;
        }

        public string ReportCrate()
        {
            return _crates.Peek();
        }

        public void AddCrate(string id)
        {
            _crates.Push(id);
        }

        public void AddCrates(string cratesToAdd)
        {
            foreach (char id in cratesToAdd.Reverse())
            {
                AddCrate(id.ToString());
            }
        }
    }
}