namespace EatFrog.Operands;

public class IndirectAddress(ulong address) : Operand
{
    public ulong Address { get; } = address;

    public override string ToString() => $"*{Address}";
}