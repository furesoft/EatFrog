namespace EatFrog.Operands;

public class RegisterRef<TRegister> : Operand
{
    private TRegister Name { get; }

    public RegisterRef(TRegister name)
    {
        Name = name;
    }
}