using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<T> : Parser<AstNode>
    where T : struct
{
    public AssemblyParser()
    {
        Register(PredefinedSymbols.Name, new OpCodeParselet<T>());
        this.AddCommonLiterals();
        this.AddArithmeticOperators();
    }
    
    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(true, true);
    }
}