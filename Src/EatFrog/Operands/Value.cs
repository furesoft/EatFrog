namespace EatFrog.Operands;

public class Value(ulong value) : Operand
{
    public ulong value { get; } = value;

    public override string ToString() => $"%{value}";
}