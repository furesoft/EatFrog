namespace EatFrog.Operands;

public class LabelRef : Operand
{
    public string Name { get; }

    public LabelRef(string name)
    {
        Name = name;
    }
    
    public override string ToString() => $"{Name}";
}