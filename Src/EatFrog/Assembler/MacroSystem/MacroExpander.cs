using EatFrog.Assembler.Nodes;
using EatFrog.Operands;

namespace EatFrog.Assembler.MacroSystem;

public class MacroExpander<TOpCode, TRegister>
    where TOpCode : struct
    where TRegister : struct
{
    private readonly Dictionary<string, MacroDefinition<TOpCode, TRegister>> _macroDefs = [];

    public void AddMacro(MacroDefinition<TOpCode, TRegister> definition) {
        _macroDefs.Add(definition.Name, definition);
    }

    public Instruction<TOpCode>[] ExpandMacro(MacroNode invocation)
    {
        var macroDef = _macroDefs[invocation.Mnemnonic.Name] ?? throw new MacroNotFoundException(invocation.Mnemnonic.Name);

        var args = ExtractArguments(invocation);
        var expandedInstructions = macroDef.Expand(args);

        return expandedInstructions;
    }

    private static Operand[] ExtractArguments(MacroNode invocation)
    {
        var operands = new List<Operand>();

        foreach(var operand in invocation.Arguments) {
            operands.Add(InstructionConversionVisitor<TOpCode, int>.VisitOperand(operand));
        }

        return [.. operands];
    }
}