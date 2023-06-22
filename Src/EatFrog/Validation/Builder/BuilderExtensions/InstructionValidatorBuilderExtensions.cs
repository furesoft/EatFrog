using EatFrog.Validation.Rules;

namespace EatFrog.Validation.Builder.BuilderExtensions;

public static class InstructionValidatorBuilderExtensions
{
    public static IInstructionValidatorBuilder<TOpcode> MaxOperands<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder, int maxOperandCount)
        where TOpcode : struct
    {
        return builder.AddRule(new MaxOperandCountRule<TOpcode>(maxOperandCount));
    }
    
    public static IInstructionValidatorBuilder<TOpcode> OpCount<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder, int count)
        where TOpcode : struct
    {
        return builder.AddRule(new OperandCountRule<TOpcode>(count));
    }
    
    public static IInstructionValidatorBuilder<TOpcode> NoOperands<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder)
        where TOpcode : struct
    {
        return builder.MaxOperands(0);
    }

    public static IInstructionValidatorBuilder<TOpcode> Operand<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder, int operandIndex,
        Action<IOperandValidationRuleBuilder> ruleBuilder)
        where TOpcode : struct
    {
        return builder.AddRule(new SingleOperandValidatorRule<TOpcode>(operandIndex, ruleBuilder));
    }

    public static IInstructionValidatorBuilder<TOpcode> Or<TOpcode>(this IInstructionValidatorBuilder<TOpcode> builder,
        InstructionValidatorRule<TOpcode> lhs, InstructionValidatorRule<TOpcode> rhs)
        where TOpcode : struct
    {
        return builder.AddRule(new DisjunctionValidatorRule<TOpcode>(lhs, rhs));
    }
}