namespace EatFrog.Validation;

public abstract class InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    public abstract ValidationResult Validate(Instruction<TOpcode> instruction);
}