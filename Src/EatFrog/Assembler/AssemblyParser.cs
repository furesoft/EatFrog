using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpcode, TRegister> : Parser
    where TOpcode : struct
    where TRegister : struct
{
    protected override void Init()
    {
        Block(PredefinedSymbols.SOF, PredefinedSymbols.EOF, PredefinedSymbols.EOL);
        
        Register("#opcode", new InstructionParselet<TOpcode>());
        Register("#register", new RegisterParselet<TRegister>());
        
        this.AddCommonLiterals();
        this.AddArithmeticOperators();
        
        Group("[", "]");
        
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