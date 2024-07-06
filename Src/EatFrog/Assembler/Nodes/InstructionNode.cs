using System.Collections.Immutable;
using Silverfly.Nodes;

namespace EatFrog.Assembler.Nodes;

public record InstructionNode<TOpCode>(TOpCode Opcode, ImmutableList<AstNode> Operands) : AstNode
    where TOpCode : struct
{

    public Instruction<TOpCode> ToInstruction() => new Instruction<TOpCode>(Opcode); //ToDo: convert operandnodes to operand
}
