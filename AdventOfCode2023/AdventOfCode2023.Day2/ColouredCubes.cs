using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day2;

public partial record ColouredCubes(int NumberOfRedCubes, int NumberOfGreenCubes, int NumberOfBlueCubes)
{
    [GeneratedRegex("([0-9]+) red", RegexOptions.Compiled)]
    private static partial Regex RedCubesRegex();
    
    [GeneratedRegex("([0-9]+) green", RegexOptions.Compiled)]
    private static partial Regex GreenCubesRegex();
    
    [GeneratedRegex("([0-9]+) blue", RegexOptions.Compiled)]
    private static partial Regex BlueCubesRegex();

    public int Power => NumberOfRedCubes * NumberOfGreenCubes * NumberOfBlueCubes;
    
    public static ColouredCubes Build(string selections)
    {
        var redCubes = GetAmount(RedCubesRegex().Match(selections));
        var greenCubes = GetAmount(GreenCubesRegex().Match(selections));
        var blueCubes = GetAmount(BlueCubesRegex().Match(selections));

        return new ColouredCubes(redCubes, greenCubes, blueCubes);
    }

    private static int GetAmount(Match numberOfCubesMatch)
    {
        if (!numberOfCubesMatch.Success)
        {
            return 0;
        }

        var numberOfMatches = numberOfCubesMatch.Groups.Values.Skip(1).First().Value;
        return int.Parse(numberOfMatches);
    }

    public bool IsPossible(ColouredCubes bag)
    {
        return NumberOfRedCubes <= bag.NumberOfRedCubes &&
               NumberOfGreenCubes <= bag.NumberOfGreenCubes &&
               NumberOfBlueCubes <= bag.NumberOfBlueCubes;
    }
}