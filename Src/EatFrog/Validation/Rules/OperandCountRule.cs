namespace EatFrog.Validation.Rules;

internal class OperandCountRule<TOperand>(int count) : InstructionValidatorRule<TOperand> where TOperand : struct
{
    private readonly int _count = count;

    public override ValidationResult Validate(Instruction<TOperand> instruction)
    {
        if (instruction.Operands.Length == _count)
        {
            return true;
        }

        return $"{instruction.Opcode} expects {_count} operands";
    }
}