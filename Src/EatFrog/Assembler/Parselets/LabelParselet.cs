using EatFrog.Assembler.Core.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core.Parselets;

internal class LabelParselet : IPrefixParselet
{
    public int GetBindingPower()
    {
        return 100;
    }

    public AstNode Parse(Parser parser, Token token)
    {
        return new LabelNode(token.Text.Span.ToString()).WithRange(token);
    }
}