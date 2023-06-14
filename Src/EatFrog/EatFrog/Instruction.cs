namespace EatFrog;

public class Instruction<T>
{
    public T Opcode { get; set; }
    public List<Operand> Operands { get; set; } = new();

    public override string ToString()
    {
        return Opcode + string.Join(',', Operands);
    }
}