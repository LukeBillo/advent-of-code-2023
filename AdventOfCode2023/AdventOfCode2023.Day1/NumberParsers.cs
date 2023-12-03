using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day1;

public static partial class NumberParsers
{
    private const int SingleCharacter = 1;
    
    [GeneratedRegex("(?=(one|two|three|four|five|six|seven|eight|nine|ten|[0-9]))", RegexOptions.Compiled)]
    private static partial Regex NumbersRegex();

    private static readonly IImmutableDictionary<string, int> NumbersToIntegers = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    }.ToImmutableDictionary();
    
    public static int GetFirstAndLastDigits(string line)
    {
        var firstNumber = FirstNumberFromStart(line);
        var secondNumber = FirstNumberFromEnd(line);

        var number = $"{firstNumber}{secondNumber}";

        return int.Parse(number);
    }

    private static int FirstNumberFromStart(string line)
    {
        var matches = NumbersRegex().Matches(line);
        var firstMatch = matches.First().Groups.Values.Skip(1).First();

        if (firstMatch.Value.Length is SingleCharacter)
        {
            return int.Parse(firstMatch.Value);
        }

        var hasConversion = NumbersToIntegers.TryGetValue(firstMatch.Value, out var integer);
        if (!hasConversion)
        {
            throw new InvalidCastException($"No conversion for value {firstMatch.Value}");
        }

        return integer;
    }

    private static int FirstNumberFromEnd(string line)
    {
        var matches = NumbersRegex().Matches(line);
        var lastMatch = matches.Last().Groups.Values.Skip(1).First();

        if (lastMatch.Value.Length is SingleCharacter)
        {
            return int.Parse(lastMatch.Value);
        }

        var hasConversion = NumbersToIntegers.TryGetValue(lastMatch.Value, out var integer);
        if (!hasConversion)
        {
            throw new InvalidCastException($"No conversion for value {lastMatch.Value}");
        }

        return integer;
    }
}