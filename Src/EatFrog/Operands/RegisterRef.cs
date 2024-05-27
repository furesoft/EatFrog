namespace EatFrog.Operands;

public class RegisterRef<TRegister>(TRegister register) : Operand
{
    public TRegister Register { get; } = register;

    public override string ToString() => $"{Register}";
}