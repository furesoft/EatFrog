using EatFrog.Assembler.Core.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core.Parselets;

internal class InstructionParselet<TOpcode> : IPrefixParselet
    where TOpcode : struct
{
    public AstNode Parse(Parser parser, Token token)
    {
        var opcode = Enum.Parse<TOpcode>(token.ToString(), true);
        var operands = parser.ParseSeperated(PredefinedSymbols.Comma, PredefinedSymbols.EOL, PredefinedSymbols.EOF);

        return new InstructionNode<TOpcode>(opcode, operands).WithRange(token, parser.LookAhead(0));
    }
}
