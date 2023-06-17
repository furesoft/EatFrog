using EatFrog.Operands;
using EatFrog.Validation.Rules;
using EatFrog.Validation.Rules.OperandRules;

namespace EatFrog.Validation.Builder.BuilderExtensions;

public static class OperandValidatorBuilderExtensions
{
    public static IOperandValidationRuleBuilder OfType<TOperandType>(this IOperandValidationRuleBuilder builder)
        where TOperandType : Operand
    {
        return builder.AddRule(new OperandTypeRule<TOperandType>());
    }
    
    public static IOperandValidationRuleBuilder NotOfType<TOperandType>(this IOperandValidationRuleBuilder builder)
        where TOperandType : Operand
    {
        return builder.AddRule(new OperandNotTypeRule<TOperandType>());
    }

    public static IOperandValidationRuleBuilder Or(this IOperandValidationRuleBuilder builder,
        IOperandValidationRule lhs, IOperandValidationRule rhs)
    {
        return builder.AddRule(new DisjunctionOperandValidatorRule(lhs, rhs));
    }
}