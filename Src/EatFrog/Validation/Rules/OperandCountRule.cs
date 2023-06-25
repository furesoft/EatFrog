namespace EatFrog.Validation.Rules;

internal class OperandCountRule<TOperand> : InstructionValidatorRule<TOperand> where TOperand : struct
{
    private readonly int _count;

    public OperandCountRule(int count)
    {
        _count = count;
    }

    public override ValidationResult Validate(Instruction<TOperand> instruction)
    {
        if (instruction.Operands.Length == _count)
        {
            return true;
        }

        return $"{instruction.Opcode} expects {_count} operands";
    }
}