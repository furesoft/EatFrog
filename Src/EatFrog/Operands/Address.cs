namespace EatFrog.Operands;

public class Address(ulong value) : Operand
{
    public ulong Value { get; } = value;

    public override string ToString() => $"{Value}";
}