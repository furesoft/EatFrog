using EatFrog.Validation.Rules;

namespace EatFrog.Validation.Builder;

public interface IOperandValidationRuleBuilder
{
    IOperandValidationRuleBuilder AddRule(IOperandValidationRule rule);
}