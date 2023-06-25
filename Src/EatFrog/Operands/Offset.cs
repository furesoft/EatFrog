namespace EatFrog.Operands;

public class Offset : Operand
{
    public long Value { get; }

    public Offset(long value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}