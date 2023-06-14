namespace EatFrog.Operands;

public class Address : Operand
{
    private ulong Value { get; }

    public Address(ulong value)
    {
        Value = value;
    }
}