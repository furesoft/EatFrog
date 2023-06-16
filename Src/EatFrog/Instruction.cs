using EatFrog.Operands;

namespace EatFrog;

public class Instruction<T>
{
    public T Opcode { get; set; }
    public List<Operand> Operands { get; set; } = new();

    public Instruction(T opcode)
    {
        Opcode = opcode;
    }

    public override string ToString()
    {
        return Opcode + string.Join(',', Operands);
    }
}