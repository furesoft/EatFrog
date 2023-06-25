using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

internal class OperandTypeRule<TOperandType> : IOperandValidationRule
    where TOperandType : Operand
{
    public ValidationResult Validate(Operand operand)
    {
        if (operand is TOperandType)
        {
            return true;
        }

        return $"Expects {typeof(TOperandType)}";
    }
}