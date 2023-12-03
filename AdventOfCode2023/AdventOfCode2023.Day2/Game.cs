using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day2;

public partial record Game(int Id, IList<ColouredCubes> CubeSelections)
{
    [GeneratedRegex("Game ([0-9]+):", RegexOptions.Compiled)]
    private static partial Regex GameRegex();

    private static readonly ColouredCubes Bag = new ColouredCubes(12, 13, 14);
    
    public static Game FromInput(string line)
    {
        var gameMatch = GameRegex().Match(line);
        var gameId = int.Parse(gameMatch.Groups.Values.Skip(1).First().Value);

        var cubeSelections = new string(line
            .SkipWhile(character => character is not ':')
            .ToArray());

        var colouredCubesSelections = cubeSelections
            .Split(";")
            .Select(ColouredCubes.Build)
            .ToList();

        return new Game(gameId, colouredCubesSelections);
    }

    public bool IsPossible() => CubeSelections.All(selection => selection.IsPossible(Bag));

    public ColouredCubes GetFewestNumberOfCubes()
    {
        var fewestNumberOfRedCubes = CubeSelections
            .Select(selection => selection.NumberOfRedCubes)
            .Max();
        
        var fewestNumberOfGreenCubes = CubeSelections
            .Select(selection => selection.NumberOfGreenCubes)
            .Max();
        
        var fewestNumberOfBlueCubes = CubeSelections
            .Select(selection => selection.NumberOfBlueCubes)
            .Max();

        return new ColouredCubes(fewestNumberOfRedCubes, fewestNumberOfGreenCubes, fewestNumberOfBlueCubes);
    }
}