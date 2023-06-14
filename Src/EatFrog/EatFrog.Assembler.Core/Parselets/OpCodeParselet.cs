using EatFrog.Assembler.Core.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core.Parselets;

public class OpCodeParselet<T> : IPrefixParselet<AstNode>
    where T : struct
{
    public AstNode Parse(Parser<AstNode> parser, Token token)
    {
        return new OpCodeNode<T>(Enum.Parse<T>(token.ToString(), true)).WithRange(token);
    }
}