namespace EatFrog.Validation;

public interface IInstructionValidatorBuilder<TOpcode>
    where TOpcode : struct
{
    IInstructionValidatorBuilder<TOpcode> AddRule(InstructionValidatorRule<TOpcode> rule);
}