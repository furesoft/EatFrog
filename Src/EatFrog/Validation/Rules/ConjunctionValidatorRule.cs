namespace EatFrog.Validation.Rules;

public class ConjunctionValidatorRule<TOpcode>(InstructionValidatorRule<TOpcode> lhs, InstructionValidatorRule<TOpcode> rhs) : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly InstructionValidatorRule<TOpcode> _lhs = lhs;
    private readonly InstructionValidatorRule<TOpcode> _rhs = rhs;

    public override ValidationResult Validate(Instruction<TOpcode> instruction)
    {
        return _lhs.Validate(instruction) && _rhs.Validate(instruction);
    }
}