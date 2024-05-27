using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class DisjunctionOperandValidatorRule(IOperandValidationRule lhs, IOperandValidationRule rhs) : IOperandValidationRule
{
    private readonly IOperandValidationRule _lhs = lhs;
    private readonly IOperandValidationRule _rhs = rhs;

    public ValidationResult Validate(Operand operand)
    {
        return _lhs.Validate(operand) || _rhs.Validate(operand);
    }
}