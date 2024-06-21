using EatFrog.Assembler.MacroSystem;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Lexing;

namespace EatFrog.Assembler.Matcher;

internal class MacroMatcher<TOpCode, TRegister, TMacroStorage>(MacroExpander<TOpCode, TRegister, TMacroStorage> expander) : IMatcher
    where TOpCode : struct
    where TRegister : struct
    where TMacroStorage : MacroStorage<TOpCode, TRegister>, new()
{

    public Token Build(Lexer lexer, ref int index, ref int column, ref int line)
    {
        var oldColumn = column;
        var oldIndex = index;

        foreach (var macro in expander.Storage.Macros)
        {
            if (lexer.IsMatch(macro.Key))
            {
                lexer.Advance(macro.Key.Length);
                break;
            }
        }

        return new Token((Symbol)"#macro", lexer.Document.Source[oldIndex..index], line, oldColumn).WithDocument(lexer.Document);
    }

    public bool Match(Lexer lexer, char c)
    {
        foreach (var macro in expander.Storage.Macros)
        {
            if (lexer.IsMatch(macro.Key))
            {
                return true;
            }
        }

        return false;
    }
}