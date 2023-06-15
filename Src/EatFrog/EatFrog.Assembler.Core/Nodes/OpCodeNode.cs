using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

public class InstructionNode<T> : AstNode
    where T : struct
{
    public T Opcode { get; }
    public List<AstNode> Operands { get; }

    public InstructionNode(T opcode, List<AstNode> operands)
    {
        Opcode = opcode;
        Operands = operands;
    }
}