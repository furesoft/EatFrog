using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpcode, TRegister> : Parser<AstNode>
    where TOpcode : struct
    where TRegister : struct
{
    public AssemblyParser()
    {
        Register("#opcode", new InstructionParselet<TOpcode>());
        Register("#register", new RegisterParselet<TRegister>());
        
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
        lexer.AddMatcher(new RegisterMatcher<TRegister>());

        lexer.Ignore(' ');
    }
}