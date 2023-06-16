namespace EatFrog.Validation;

public abstract class InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    public abstract bool Validate(Instruction<TOpcode> instruction);
}