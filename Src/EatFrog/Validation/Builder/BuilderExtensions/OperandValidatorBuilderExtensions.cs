using EatFrog.Operands;
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
}