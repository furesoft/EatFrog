using EatFrog.Operands;

namespace EatFrog.Assembler.MacroSystem;

public abstract class MacroDefinition<TOpCode, TRegister>
    where TOpCode : struct
    where TRegister : struct
{
    public abstract string Name { get; }
    public abstract Instruction<TOpCode>[] Expand(Operand[] args);
}
