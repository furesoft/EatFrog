using EatFrog.Assembler.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Parselets;

internal class RegisterParselet<TRegister> : IPrefixParselet
    where TRegister : struct
{
    public AstNode Parse(Parser parser, Token token)
    {
        var register = Enum.Parse<TRegister>(token.ToString(), true);

        return new RegisterRefNode<TRegister>(register).WithRange(token, parser.LookAhead(0));
    }
}
