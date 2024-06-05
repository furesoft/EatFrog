namespace EatFrog.Assembler.MacroSystem;

public abstract class MacroStorage<TOpCode, TRegister>
    where TOpCode : struct
    where TRegister : struct
{
    public readonly Dictionary<string, MacroDefinition<TOpCode, TRegister>> Macros = [];

    protected void AddMacro(MacroDefinition<TOpCode, TRegister> definition)
    {
        Macros.Add(definition.Name, definition);
    }
}