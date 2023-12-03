using System.Collections.Immutable;

namespace AdventOfCode2023.Day3;

public record Position
{
    public int X { get; init; }

    public int Y { get; init; }

    public int GridRows { get; init; }

    public int GridColumns { get; init; }

    public Position? Above { get; init; }

    public Position? Below { get; init; }

    public Position? Left { get; init; }

    public Position? Right { get; init; }

    public Position? TopLeft { get; init; }

    public Position? TopRight { get; init; }

    public Position? BelowLeft { get; init; }

    public Position? BelowRight { get; init; }

    public Position(int y, int x, int gridRows, int gridColumns)
    {
        Y = y;
        X = x;
        GridRows = gridRows;
        GridColumns = gridColumns;

        Above = Y is 0 ? null : this with { Y = Y - 1 };
        Below = Y == (GridRows - 1) ? null : this with { Y = Y + 1 };
        Left = X is 0 ? null : this with { X = X - 1 };
        Right = X == (GridColumns - 1) ? null : this with { X = X + 1 };
        TopLeft = Above is null || Left is null ? null : this with { Y = Above.Y, X = Left.X };
        TopRight = Above is null || Right is null ? null : this with { Y = Above.Y, X = Right.X };
        BelowLeft = Below is null || Left is null ? null : this with { Y = Below.Y, X = Left.X };
        BelowRight = Below is null || Right is null ? null : this with { Y = Below.Y, X = Right.X };

        AdjacentPositions = new List<Position?> { Above, Below, Left, Right, TopLeft, TopRight, BelowLeft, BelowRight }
            .Where(position => position is not null)
            .ToImmutableList()!;
    }

    public IImmutableList<Position> AdjacentPositions;
}