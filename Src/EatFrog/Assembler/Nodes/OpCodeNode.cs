using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

public class InstructionNode<TOpCode>(TOpCode opcode, List<AstNode> operands) : AstNode
    where TOpCode : struct
{
    public TOpCode Opcode { get; } = opcode;
    public List<AstNode> Operands { get; } = operands;

    public Instruction<TOpCode> ToInstruction() => new Instruction<TOpCode>(Opcode); //ToDo: convert operandnodes to operand
}
