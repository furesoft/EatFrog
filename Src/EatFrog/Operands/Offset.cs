namespace EatFrog.Operands;

public class Offset(long value) : Operand
{
    public long Value { get; } = value;

    public override string ToString()
    {
        return $"{Value}";
    }
}