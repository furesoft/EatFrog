using Furesoft.PrattParser.Lexing.Matcher;

namespace EatFrog.Assembler.Matcher;

internal class RegisterMatcher<T> : EnumMatcher<T>
    where T : struct
{
    public RegisterMatcher() : base("#register")
    {
    }
}
