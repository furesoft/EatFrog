namespace EatFrog.Operands;

public class Value : Operand
{
    public ulong Amount { get; }

    public Value(ulong amount)
    {
        Amount = amount;
    }
}