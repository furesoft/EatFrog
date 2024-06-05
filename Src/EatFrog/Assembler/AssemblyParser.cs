using EatFrog.Assembler.Core.Matcher;
using EatFrog.Assembler.Core.Parselets;
using EatFrog.Assembler.MacroSystem;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Parselets;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpCode, TRegister, TMacroStorage> : Parser
    where TOpCode : struct
    where TRegister : struct
    where TMacroStorage : MacroStorage<TOpCode, TRegister>, new()
{
    public static MacroExpander<TOpCode, TRegister, TMacroStorage> MacroExpander = new();

    protected override void InitParselets()
    {
        Block(PredefinedSymbols.SOF, PredefinedSymbols.EOF, PredefinedSymbols.EOL);
        
        Register("#opcode", new InstructionParselet<TOpCode>());
        Register("#register", new RegisterParselet<TRegister>());
        Register("#macro", new MacroParselet<TOpCode, TRegister>());

        Register(PredefinedSymbols.Name, new NameParselet());

        this.AddCommonLiterals();
        this.AddArithmeticOperators();

        Prefix("$", 100);
        
        Group("[", "]");
    }

    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(true, true);

        lexer.AddMatcher(new OpcodeMatcher<TOpCode>());
        lexer.AddMatcher(new RegisterMatcher<TRegister>());
        lexer.AddMatcher(new MacroMatcher<TOpCode, TRegister, TMacroStorage>(MacroExpander));

        lexer.Ignore(' ');
    }
}