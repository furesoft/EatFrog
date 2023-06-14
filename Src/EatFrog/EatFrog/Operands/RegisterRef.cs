namespace EatFrog.Operands;

public class RegisterRef : Operand
{
    private string Name { get; }

    public RegisterRef(string name)
    {
        Name = name;
    }
}