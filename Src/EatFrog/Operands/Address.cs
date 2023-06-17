namespace EatFrog.Operands;

public class Address : Operand
{
    public ulong Value { get; }

    public Address(ulong value)
    {
        Value = value;
    }

    public override string ToString() => $"{Value}";
}