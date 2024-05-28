namespace EatFrog.Assembler.Core.Matcher;

internal class RegisterMatcher<T> : EnumMatcher<T>
    where T : struct
{
    public RegisterMatcher() : base("#register")
    {
    }
}