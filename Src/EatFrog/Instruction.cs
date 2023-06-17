using EatFrog.Operands;

namespace EatFrog;

public class Instruction<TOpcode>
    where TOpcode : struct
{
    public TOpcode Opcode { get; }
    public Operand[] Operands { get; set; }

    public Instruction(TOpcode opcode)
    {
        Opcode = opcode;
    }

    public Instruction(TOpcode opcode, params Operand[] operands)
        : this(opcode)
    {
        Operands = operands;
    }

    public override string ToString()
    {
        return Opcode + " " + string.Join(',', Operands.Select(_=> _.ToString()));
    }
}