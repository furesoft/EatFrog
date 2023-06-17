using EatFrog.Operands;

namespace EatFrog.Validation.Rules;

public interface IOperandValidationRule
{
    bool Validate(Operand operand);
}