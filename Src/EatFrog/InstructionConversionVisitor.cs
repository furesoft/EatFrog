using EatFrog.Assembler.Core.Nodes;
using EatFrog.Assembler.MacroSystem;
using EatFrog.Assembler.Nodes;
using EatFrog.Operands;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Furesoft.PrattParser.Nodes.Operators;

namespace EatFrog;

internal class InstructionConversionVisitor<TOpCode, TRegister> : IVisitor<IEnumerable<Instruction<TOpCode>>>
    where TOpCode : struct
    where TRegister : struct
{
    public readonly MacroExpander<TOpCode, TRegister> Expander = new();

    public IEnumerable<Instruction<TOpCode>> Visit(AstNode node)
    {
        var instructions = new List<Instruction<TOpCode>>();

        if (node is BlockNode block)
        {
            foreach (var child in block.Children)
            {
                if (child is InstructionNode<TOpCode> instr) {
                    instructions.Add(VisitInstruction(instr));
                }
                else if (child is MacroNode macro) {
                    instructions.AddRange(Expander.ExpandMacro(macro));
                }
            }
        }

        return instructions;
    }

    private Instruction<TOpCode> VisitInstruction(InstructionNode<TOpCode> node)
    {
        var instr = new Instruction<TOpCode>(node.Opcode);

        var operands = new List<Operand>();
        foreach (var operand in node.Operands)
        {
            operands.Add(VisitOperand(operand));
        }

        instr.Operands = [.. operands];

        return instr;
    }

    public static Operand VisitOperand(AstNode operand)
    {
        return operand switch
        {
            RegisterRefNode<TRegister> regRef => new RegisterRef<TRegister>(regRef.Register),
            LiteralNode<ulong> literal => new Value(literal.Value),
            PrefixOperatorNode labelRef
                when labelRef.Operator == PredefinedSymbols.Dollar && labelRef.Expr is NameNode name => new LabelRef(name.Name),
            _ => throw new InvalidOperationException($"Invalid Operand '{operand}'")
        };
    }
}