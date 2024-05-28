using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class OperandNotTypeRule<TOperandType> : IOperandValidationRule
    where TOperandType : Operand
{
    public ValidationResult Validate(Operand operand)
    {
        if (operand is not TOperandType)
        {
            return true;
        }

        return $"Operand cannot be {operand.GetType()}";
    }
}