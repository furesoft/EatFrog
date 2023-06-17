using EatFrog.Operands;
using EatFrog.Validation.Rules;
using EatFrog.Validation.Rules.OperandRules;

namespace EatFrog.Validation.Builder;

internal class OperandValidationRuleBuilder : IOperandValidationRuleBuilder
{
    private IOperandValidationRule _rule;

    public IOperandValidationRuleBuilder AddRule(IOperandValidationRule rule)
    {
        _rule = _rule == null ? rule : new ConjunctionOperandValidatorRule(_rule, rule);

        return this;
    }

    public bool Validate(Operand instructionOperand)
    {
        return _rule.Validate(instructionOperand);
    }
}