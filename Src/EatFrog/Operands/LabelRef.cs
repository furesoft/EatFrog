namespace EatFrog.Operands;

public class LabelRef : Operand
{
    private string Name { get; }
    private ulong Address { get; }

    public LabelRef(string name, ulong address)
    {
        Name = name;
        Address = address;
    }
}