using Silverfly.Lexing.Matcher;

namespace EatFrog.Assembler.Matcher;

internal class OpcodeMatcher<T> : EnumMatcher<T>
    where T : struct
{
    public OpcodeMatcher() : base("#opcode")
    {
    }
}
