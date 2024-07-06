using EatFrog.Assembler.Nodes;
using Silverfly;
using Silverfly.Nodes;
using Silverfly.Parselets;

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