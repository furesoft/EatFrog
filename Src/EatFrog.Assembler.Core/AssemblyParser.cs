using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpcode> : Parser<AstNode>
    where TOpcode : struct
{
    public AssemblyParser()
    {
        Register("#opcode", new InstructionParselet<TOpcode>());
        
        this.AddCommonLiterals();
        this.AddArithmeticOperators();
        
        Group("[", "]");
        Block(PredefinedSymbols.EOL, PredefinedSymbols.EOF);
        
        //Register(PredefinedSymbols.Name, new LabelParselet());
    }
    
    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(true, true);
        lexer.AddMatcher(new OpcodeMatcher<TOpcode>());
        lexer.Ignore(' ');
    }
}