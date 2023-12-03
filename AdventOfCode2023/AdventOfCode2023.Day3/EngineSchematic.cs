using System.Collections.Immutable;

namespace AdventOfCode2023.Day3;

public class EngineSchematic(List<List<SchematicEntry>> SchematicGrid)
{
    public static EngineSchematic FromInput(string[] lines)
    {
        var schematicGrid = new List<List<SchematicEntry>>();
        
        for (var y = 0; y < lines.Length; y++)
        {
            var row = lines[y];
            var schematicRow = new List<SchematicEntry>();

            var currentPartNumber = string.Empty;

            for (var x = 0; x < row.Length; x++)
            {
                var character = lines[y][x].ToString();
                var position = new Position(y, x, lines.Length, row.Length);
                var hasAdjacentSymbol = HasAdjacentSymbol(position.AdjacentPositions, lines);
                
                var schematicEntry = new SchematicEntry(character, position, hasAdjacentSymbol);

                schematicRow.Add(schematicEntry);
            }

            schematicGrid.Add(schematicRow);
        }

        return new EngineSchematic(schematicGrid);
    }

    private static bool HasAdjacentSymbol(IImmutableList<Position> adjacentPositions, string[] lines)
    {
        return adjacentPositions
            .Select(position => lines[position.Y][position.X])
            .Any(entry => entry is not '.' && !int.TryParse(entry.ToString(), out _));
    }

    public List<int> GetPartNumbers()
    {
        return new List<int>();
    }
}