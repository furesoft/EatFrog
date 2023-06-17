using EatFrog.Validation.Rules.OperandRules;

namespace EatFrog.Validation.Builder.BuilderExtensions;

public static class OperandValidatorBuilderExtensions
{
    public static IOperandValidationRuleBuilder OfType<TOperandType>(this IOperandValidationRuleBuilder builder)
    {
        return builder.AddRule(new OperandTypeRule<TOperandType>());
    }
}