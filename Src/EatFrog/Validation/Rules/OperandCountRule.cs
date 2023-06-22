namespace EatFrog.Validation.Rules;

internal class OperandCountRule<TOperand> : InstructionValidatorRule<TOperand> where TOperand : struct
{
    private readonly int _max;

    public OperandCountRule(int max)
    {
        _max = max;
    }
    
    public override bool Validate(Instruction<TOperand> instruction)
    {
        return instruction.Operands.Length == _max;
    }
}