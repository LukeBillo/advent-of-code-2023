using AdventOfCode2023.Day2;

var input = await File.ReadAllLinesAsync("./Input/input.puzzle.txt");
var games = input.Select(Game.FromInput).ToList();

/* Part 1
var possibleGames = games
    .Where(game => game.IsPossible())
    .Select(game => game.Id)
    .ToList();

var impossibleGames = games
    .Where(game => !game.IsPossible())
    .Select(game => game.Id)
    .ToList();

Console.WriteLine($"Possible games ({possibleGames.Count}): {string.Join(",", possibleGames)}");
Console.WriteLine($"Impossible games ({impossibleGames.Count}): {string.Join(",", impossibleGames)}");

Console.WriteLine(possibleGames.Sum());
*/

var gamePowers = games
    .Select(game => game.GetFewestNumberOfCubes())
    .Select(game => game.Power)
    .ToList();

Console.WriteLine($"Game powers: {string.Join(",", gamePowers)}");
    
var sumOfPowers = gamePowers.Sum();

Console.WriteLine(sumOfPowers);