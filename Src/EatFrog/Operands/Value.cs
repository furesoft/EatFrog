namespace EatFrog.Operands;

public class Value(ulong amount) : Operand
{
    public ulong Amount { get; } = amount;

    public override string ToString() => $"%{Amount}";
}