namespace EatFrog.Validation.Rules;

public class MaxOperandCountRule<TOperand> : InstructionValidatorRule<TOperand> where TOperand : struct
{
    private readonly int _maxOperands;

    public MaxOperandCountRule(int maxOperands)
    {
        _maxOperands = maxOperands;
    }
    
    public override bool Validate(Instruction<TOperand> instruction)
    {
        return instruction.Operands.Count <= _maxOperands;
    }
}