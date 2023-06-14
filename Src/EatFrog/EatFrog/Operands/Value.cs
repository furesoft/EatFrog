namespace EatFrog.Operands;

public class Value : Operand
{
    private ulong Amount { get; }

    public Value(ulong amount)
    {
        Amount = amount;
    }
}