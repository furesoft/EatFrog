namespace EatFrog.Operands;

public class IndirectAddress : Operand
{
    private ulong Address { get; }

    public IndirectAddress(ulong address)
    {
        Address = address;
    }
}