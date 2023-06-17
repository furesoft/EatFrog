namespace EatFrog.Operands;

public class IndirectAddress : Operand
{
    public ulong Address { get; }

    public IndirectAddress(ulong address)
    {
        Address = address;
    }
    
    public override string ToString() => $"*{Address}";
}