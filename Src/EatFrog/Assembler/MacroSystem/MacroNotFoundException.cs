namespace EatFrog.Assembler.MacroSystem;

public class MacroNotFoundException(string macro) : Exception
{
    public string Macro { get; } = macro;
}
