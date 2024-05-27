using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

internal class InstructionNode<T>(T opcode, List<AstNode> operands) : AstNode
    where T : struct
{
    public T Opcode { get; } = opcode;
    public List<AstNode> Operands { get; } = operands;
}