using EatFrog.Validation.Rules;

namespace EatFrog.Validation;

public static class InstructionValidatorBuilderExtensions
{
    public static IInstructionValidatorBuilder<TOpcode> MaxOperands<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder, int maxOperandCount)
        where TOpcode : struct
    {
        return builder.AddRule(new MaxOperandCountRule<TOpcode>(maxOperandCount));
    }
    
    public static IInstructionValidatorBuilder<TOpcode> NoOperands<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder)
        where TOpcode : struct
    {
        return builder.MaxOperands(0);
    }
}