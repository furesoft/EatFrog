using EatFrog.Operands;

namespace EatFrog.Validation.Rules.OperandRules;

public class KindValidatorRule<TFirst> : IOperandValidationRule
{
    public bool Validate(Operand operand)
    {
        return operand is TFirst;
    }
}

public class KindValidatorRule<TFirst, TSecond> : IOperandValidationRule
{
    public bool Validate(Operand operand)
    {
        return operand is TFirst or TSecond;
    }
}

public class KindValidatorRule<TFirst, TSecond, TThird> : IOperandValidationRule
{
    public bool Validate(Operand operand)
    {
        return operand is TFirst or TSecond or TThird;
    }
}

public class KindValidatorRule<TFirst, TSecond, TThird, TFourth> : IOperandValidationRule
{
    public bool Validate(Operand operand)
    {
        return operand is TFirst or TSecond or TThird or TFourth;
    }
}