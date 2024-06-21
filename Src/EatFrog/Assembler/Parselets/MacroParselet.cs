using EatFrog.Assembler.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Parselets;

internal class MacroParselet<TOpCode, TRegister> : IPrefixParselet
    where TOpCode : struct
{
    public AstNode Parse(Parser parser, Token token)
    {
        var operands = parser.ParseSeperated(PredefinedSymbols.Comma, bindingPower: 100, PredefinedSymbols.EOL, PredefinedSymbols.EOF);

        return new MacroNode(token.Text.ToString(), operands).WithRange(token, parser.LookAhead(0));
    }
}
