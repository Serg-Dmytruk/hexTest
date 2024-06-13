namespace HexTest.Domain.DtoModels;

public class Point2D(int x, int y)
{
    public int X { get; init; } = x;
    public int Y { get; init; } = y;
}