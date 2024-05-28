using EatFrog.Operands;

namespace EatFrog;

public class Instruction<TOpcode>(TOpcode opcode)
    where TOpcode : struct
{
    public TOpcode Opcode { get; } = opcode;
    public Operand[] Operands { get; set; } = [];

    public Instruction(TOpcode opcode, params Operand[] operands)
        : this(opcode)
    {
        Operands = operands;
    }

    public override string ToString()
    {
        return Opcode + (Operands.Length != 0 ? " " : "") + string.Join(',', Operands.Select(_=> _.ToString()));
    }
}