namespace EatFrog.Operands;

public class RegisterRef<TRegister> : Operand
{
    public TRegister Register { get; }

    public RegisterRef(TRegister register)
    {
        Register = register;
    }
    
    public override string ToString() => $"{Register}";
}