using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpcode, TRegister> : Parser
    where TOpcode : struct
    where TRegister : struct
{
    protected override void InitParselets()
    {
        Block(PredefinedSymbols.SOF, PredefinedSymbols.EOF, PredefinedSymbols.EOL);
        
        Register("#opcode", new InstructionParselet<TOpcode>());
        Register("#register", new RegisterParselet<TRegister>());

        Register(PredefinedSymbols.Name, new NameParselet());

        this.AddCommonLiterals();
        this.AddArithmeticOperators();

        Prefix("$", 100);
        
        Group("[", "]");
    }

    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(true, true);

        lexer.AddMatcher(new OpcodeMatcher<TOpcode>());
        lexer.AddMatcher(new RegisterMatcher<TRegister>());
        lexer.AddMatcher(new MacroMatcher([.. MacroExpander.Macros.Keys]));

        lexer.Ignore(' ');
    }
}