namespace EatFrog.Operands;

public class RegisterRef<TRegister> : Operand
{
    public TRegister Name { get; }

    public RegisterRef(TRegister name)
    {
        Name = name;
    }
}