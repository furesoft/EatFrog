using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class OperandTypeRule<TOperandType> : IOperandValidationRule
{
    public bool Validate(Operand operand)
    {
        return operand is TOperandType;
    }
}