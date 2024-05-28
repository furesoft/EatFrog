namespace EatFrog.Operands;

public class LabelRef(string name) : Operand
{
    public string Name { get; } = name;

    public override string ToString() => $"{Name}";
}