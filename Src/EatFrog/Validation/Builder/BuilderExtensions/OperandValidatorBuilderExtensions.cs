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
    
    public static IOperandValidationRuleBuilder Kinds<TFirst>(this IOperandValidationRuleBuilder builder,
        int operandIndex)
        where TFirst : Operand
    {
        return builder.AddRule(new KindValidatorRule<TFirst>());
    }
    
    public static IOperandValidationRuleBuilder Kinds<TFirst, TSecond>(this IOperandValidationRuleBuilder builder)
        where TFirst : Operand
        where TSecond : Operand
    {
        return builder.AddRule(new KindValidatorRule<TFirst, TSecond>());
    }
    
    public static IOperandValidationRuleBuilder Kinds<TFirst, TSecond, TThird>(this IOperandValidationRuleBuilder builder)
        where TFirst : Operand
        where TSecond : Operand
        where TThird : Operand
    {
        return builder.AddRule(new KindValidatorRule<TFirst, TSecond, TThird>());
    }
    
    public static IOperandValidationRuleBuilder Kinds<TFirst, TSecond, TThird, TFourth>(this IOperandValidationRuleBuilder builder)
        where TFirst : Operand
        where TSecond : Operand
        where TThird : Operand
        where TFourth : Operand
    {
        return builder.AddRule(new KindValidatorRule<TFirst, TSecond, TThird, TFourth>());
    }
}