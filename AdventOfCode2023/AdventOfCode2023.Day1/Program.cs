using AdventOfCode2023.Day1;

var input = await File.ReadAllLinesAsync("./Input/input.puzzle.txt");

var numbersForEachLine = input.Select(NumberParsers.GetFirstAndLastDigits).ToList();

for (var i = 0; i < numbersForEachLine.Count; i++)
{
    Console.WriteLine($"Line {i+1}: {numbersForEachLine[i]}");
}

var summedNumbers = numbersForEachLine.Sum();

Console.WriteLine($"Solution: {summedNumbers}");