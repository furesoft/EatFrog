using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<T> : Parser<AstNode>
    where T : struct
{
    public AssemblyParser()
    {
        Register("#opcode", new InstructionParselet<T>());
        
        this.AddCommonLiterals();
        this.AddArithmeticOperators();
        
        Group("[", "]");
        Block(PredefinedSymbols.EOL, PredefinedSymbols.EOF);
        
        //Register(PredefinedSymbols.Name, new LabelParselet());
    }
    
    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(true, true);
        lexer.AddMatcher(new OpcodeMatcher<T>());
        lexer.Ignore(' ');
    }
}