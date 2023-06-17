namespace EatFrog.Validation.Rules;

public class CascadeValidatorRule<TOpcode> : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly InstructionValidatorRule<TOpcode> _lhs;
    private readonly InstructionValidatorRule<TOpcode> _rhs;

    public CascadeValidatorRule(InstructionValidatorRule<TOpcode> lhs, InstructionValidatorRule<TOpcode> rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public override bool Validate(Instruction<TOpcode> instruction)
    {
        return _lhs.Validate(instruction) && _rhs.Validate(instruction);
    }
}