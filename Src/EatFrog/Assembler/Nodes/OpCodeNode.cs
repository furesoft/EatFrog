using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

public class InstructionNode<T>(T opcode, List<AstNode> operands) : AstNode
    where T : struct
{
    public T Opcode { get; } = opcode;
    public List<AstNode> Operands { get; } = operands;

    public Instruction<T> ToInstruction() => new Instruction<T>(Opcode); //ToDo: convert operandnodes to operand
}