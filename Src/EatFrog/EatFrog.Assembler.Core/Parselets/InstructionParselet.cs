﻿using EatFrog.Assembler.Core.Nodes;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core.Parselets;

public class InstructionParselet<T> : IPrefixParselet<AstNode>
    where T : struct
{
    public AstNode Parse(Parser<AstNode> parser, Token token)
    {
        var opcode = Enum.Parse<T>(token.ToString(), true);
        var operands = parser.ParseSeperated(PredefinedSymbols.Comma, PredefinedSymbols.EOL);
        
        return new InstructionNode<T>(opcode, operands).WithRange(token, parser.LookAhead(0));
    }
}