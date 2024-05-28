namespace EatFrog.Validation.Rules;

internal class MaxOperandCountRule<TOperand>(int maxOperands) : InstructionValidatorRule<TOperand> where TOperand : struct
{
    private readonly int _maxOperands = maxOperands;

    public override ValidationResult Validate(Instruction<TOperand> instruction)
    {
        if (instruction.Operands.Length <= _maxOperands)
        {
            return true;
        }

        return $"{instruction.Opcode} has more operands than it's valid";
    }
}