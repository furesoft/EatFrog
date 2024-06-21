﻿using EatFrog.Assembler.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Parselets;

internal class InstructionParselet<TOpCode> : IPrefixParselet
    where TOpCode : struct
{
    public AstNode Parse(Parser parser, Token token)
    {
        var opcode = Enum.Parse<TOpCode>(token.ToString(), true);
        var operands = parser.ParseSeperated(PredefinedSymbols.Comma, bindingPower: 0, PredefinedSymbols.EOL, PredefinedSymbols.EOF);

        return new InstructionNode<TOpCode>(opcode, operands).WithRange(token, parser.LookAhead(0));
    }
}
