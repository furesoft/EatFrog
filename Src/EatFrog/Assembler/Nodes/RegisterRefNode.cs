using Silverfly.Nodes;

namespace EatFrog.Assembler.Nodes;

public record RegisterRefNode<TRegister>(TRegister Register) : AstNode
    where TRegister : struct
{
}