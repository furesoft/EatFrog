namespace EatFrog.Validation.Builder;

public interface IInstructionValidatorBuilder<TOpcode>
    where TOpcode : struct
{
    IInstructionValidatorBuilder<TOpcode> AddRule(InstructionValidatorRule<TOpcode> rule);
}