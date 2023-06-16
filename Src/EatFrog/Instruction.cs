using EatFrog.Operands;

namespace EatFrog;

public class Instruction<TOpcode>
    where TOpcode : struct
{
    public TOpcode Opcode { get; }
    public List<Operand> Operands { get; set; } = new();

    public Instruction(TOpcode opcode)
    {
        Opcode = opcode;
    }

    public override string ToString()
    {
        return Opcode + " " + string.Join(',', Operands);
    }
}