namespace EatFrog.Assembler.Core.Matcher;

internal class OpcodeMatcher<T> : EnumMatcher<T>
    where T : struct
{
    public OpcodeMatcher() : base("#opcode")
    {
    }
}
