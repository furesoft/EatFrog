using EatFrog.Assembler.Matcher;
using EatFrog.Assembler.Parselets;
using EatFrog.Assembler.MacroSystem;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Lexing.IgnoreMatcher.Comments;
using Furesoft.PrattParser.Parselets;
using static Furesoft.PrattParser.PredefinedSymbols;

namespace EatFrog.Assembler.Core;

public class AssemblyParser<TOpCode, TRegister, TMacroStorage> : Parser
    where TOpCode : struct
    where TRegister : struct
    where TMacroStorage : MacroStorage<TOpCode, TRegister>, new()
{
    public static MacroExpander<TOpCode, TRegister, TMacroStorage> MacroExpander = new();

    protected override void InitParselets()
    {
        Block(SOF, EOF, EOL);
        
        Register("#opcode", new InstructionParselet<TOpCode>());
        Register("#register", new RegisterParselet<TRegister>());
        Register("#macro", new MacroParselet<TOpCode, TRegister>());

        Register(Name, new NameParselet());

        this.AddCommonLiterals();
        this.AddArithmeticOperators();

        Prefix("$");
        
        Group("[", "]");
    }

    protected override void InitLexer(Lexer lexer)
    {
        lexer.MatchNumber(allowHex: true, allowBin: true);

        lexer.AddMatcher(new OpcodeMatcher<TOpCode>());
        lexer.AddMatcher(new RegisterMatcher<TRegister>());
        lexer.AddMatcher(new MacroMatcher<TOpCode, TRegister, TMacroStorage>(MacroExpander));

        lexer.Ignore(new SingleLineCommentIgnoreMatcher("#"));
        lexer.Ignore(new MultiLineCommentIgnoreMatcher(SlashAsterisk, AsteriskSlash));

        lexer.Ignore(' ');
    }
}