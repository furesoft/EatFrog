using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Nodes;

public class RegisterRefNode<TRegister>(TRegister register) : AstNode
    where TRegister : struct
{
    public TRegister Register { get; } = register;
}