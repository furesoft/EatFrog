using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class DisjunctionOperandValidatorRule : IOperandValidationRule
{
    private readonly IOperandValidationRule _lhs;
    private readonly IOperandValidationRule _rhs;

    public DisjunctionOperandValidatorRule(IOperandValidationRule lhs, IOperandValidationRule rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public bool Validate(Operand operand)
    {
        return _lhs.Validate(operand) || _rhs.Validate(operand);
    }
}