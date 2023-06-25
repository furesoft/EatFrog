using EatFrog.Operands;

namespace EatFrog.Validation.Rules;

public interface IOperandValidationRule
{
    ValidationResult Validate(Operand operand);
}