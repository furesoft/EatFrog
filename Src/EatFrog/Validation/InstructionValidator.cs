using EatFrog.Validation.Builder;

namespace EatFrog.Validation;

public abstract class InstructionValidator<TOpcode> 
    where TOpcode : struct
{
    private readonly Dictionary<TOpcode, InstructionValidatorRule<TOpcode>> _rules = new();

    protected IInstructionValidatorBuilder<TOpcode> For(TOpcode opcode)
    {
        return new InstructionValidatorBuilder<TOpcode>(opcode, _rules);
    }

    public bool Validate(Instruction<TOpcode> instruction)
    {
        if (_rules.TryGetValue(instruction.Opcode, out var validator))
        {
            return validator.Validate(instruction);
        }

        return true;
    }
}