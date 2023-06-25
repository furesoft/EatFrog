using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class ConjunctionOperandValidatorRule : IOperandValidationRule
{
    private readonly IOperandValidationRule _lhs;
    private readonly IOperandValidationRule _rhs;

    public ConjunctionOperandValidatorRule(IOperandValidationRule lhs, IOperandValidationRule rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public ValidationResult Validate(Operand operand)
    {
        return _lhs.Validate(operand) && _rhs.Validate(operand);
    }
}