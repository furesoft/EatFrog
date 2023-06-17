using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class OperandNotTypeRule<TOperandType> : IOperandValidationRule
    where TOperandType : Operand
{
    public bool Validate(Operand operand)
    {
        return operand is not TOperandType;
    }
}