using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

public class OpCodeNode<T> : AstNode
    where T : struct
{
    public T Opcode { get; }

    public OpCodeNode(T opcode)
    {
        Opcode = opcode;
    }
}