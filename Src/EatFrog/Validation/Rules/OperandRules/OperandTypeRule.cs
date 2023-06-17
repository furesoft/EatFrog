using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class OperandTypeRule<TOperandType> : IOperandValidationRule
    where TOperandType : Operand
{
    public bool Validate(Operand operand)
    {
        return operand is TOperandType;
    }
}