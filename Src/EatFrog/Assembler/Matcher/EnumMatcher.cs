using Furesoft.PrattParser;
using Furesoft.PrattParser.Lexing;

namespace EatFrog.Assembler.Core.Matcher;

internal class EnumMatcher<T>(string symbol) : ILexerMatcher
    where T : struct
{
    public bool Match(Lexer lexer, char c)
    {
        foreach (var name in Enum.GetNames(typeof(T)))
        {
            if (lexer.IsMatch(name.ToLower()))
            {
                return true;
            }
        }

        return false;
    }

    public Token Build(Lexer lexer, ref int index, ref int column, ref int line)
    {
        var oldColumn = column;
        var oldIndex = index;

        foreach (var name in Enum.GetNames(typeof(T)))
        {
            if (lexer.IsMatch(name.ToLower()))
            {
                lexer.Advance(name.Length);
                break;
            }
        }

        return new(symbol, lexer.Document.Source.Slice(oldIndex, index - oldIndex), line, oldColumn);
    }
}
