namespace EatFrog.Validation.Rules;

public class ConjunctionValidatorRule<TOpcode> : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly InstructionValidatorRule<TOpcode> _lhs;
    private readonly InstructionValidatorRule<TOpcode> _rhs;

    public ConjunctionValidatorRule(InstructionValidatorRule<TOpcode> lhs, InstructionValidatorRule<TOpcode> rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public override bool Validate(Instruction<TOpcode> instruction)
    {
        return _lhs.Validate(instruction) && _rhs.Validate(instruction);
    }
}

public class DisjunctionValidatorRule<TOpcode> : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly InstructionValidatorRule<TOpcode> _lhs;
    private readonly InstructionValidatorRule<TOpcode> _rhs;

    public DisjunctionValidatorRule(InstructionValidatorRule<TOpcode> lhs, InstructionValidatorRule<TOpcode> rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public override bool Validate(Instruction<TOpcode> instruction)
    {
        return _lhs.Validate(instruction) || _rhs.Validate(instruction);
    }
}