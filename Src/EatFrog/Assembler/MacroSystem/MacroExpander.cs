using EatFrog.Assembler.Nodes;
using EatFrog.Operands;

namespace EatFrog.Assembler.MacroSystem;

public class MacroExpander<TOpCode, TRegister, TMacroStorage>
    where TOpCode : struct
    where TRegister : struct
    where TMacroStorage : MacroStorage<TOpCode, TRegister>, new()
{
    public readonly TMacroStorage Storage = new();

    public Instruction<TOpCode>[] ExpandMacro(MacroNode invocation)
    {
        var macroDef = Storage.Macros[invocation.Mnemnonic] ?? throw new MacroNotFoundException(invocation.Mnemnonic);

        var args = ExtractArguments(invocation);
        var expandedInstructions = macroDef.Expand(args);

        return expandedInstructions;
    }

    private static Operand[] ExtractArguments(MacroNode invocation)
    {
        var operands = new List<Operand>();

        foreach(var operand in invocation.Arguments) {
            operands.Add(InstructionConversionVisitor<TOpCode, TRegister, TMacroStorage>.VisitOperand(operand));
        }

        return [.. operands];
    }
}