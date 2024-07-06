using EatFrog.Assembler.Nodes;
using Silverfly;
using Silverfly.Nodes;
using Silverfly.Parselets;

namespace EatFrog.Assembler.Parselets;

internal class InstructionParselet<TOpcode> : IPrefixParselet
    where TOpcode : struct
{
    public AstNode Parse(Parser parser, Token token)
    {
        var opcode = Enum.Parse<TOpcode>(token.ToString(), true);
        var operands = parser.ParseSeperated(PredefinedSymbols.Comma, bindingPower: 0, PredefinedSymbols.EOL, PredefinedSymbols.EOF);

        return new InstructionNode<TOpcode>(opcode, operands).WithRange(token, parser.LookAhead(0));
    }
}
