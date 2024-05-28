using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

public class KindValidatorRule<TFirst> : IOperandValidationRule
{
    public ValidationResult Validate(Operand operand)
    {
        if (operand is TFirst)
        {
            return true;
        }

        return $"{operand} has to be of type {typeof(TFirst)}";
    }
}

public class KindValidatorRule<TFirst, TSecond> : IOperandValidationRule
{
    public ValidationResult Validate(Operand operand)
    {
        if (operand is TFirst or TSecond)
        {
            return true;
        }

        return $"{operand} has to be of type {typeof(TFirst)} or {typeof(TSecond)}";
    }
}

public class KindValidatorRule<TFirst, TSecond, TThird> : IOperandValidationRule
{
    public ValidationResult Validate(Operand operand)
    {
        if (operand is TFirst or TSecond or TThird)
        {
            return true;
        }

        return $"{operand} has to be of type {typeof(TFirst)} or {typeof(TSecond)} or {typeof(TThird)}";
    }
}