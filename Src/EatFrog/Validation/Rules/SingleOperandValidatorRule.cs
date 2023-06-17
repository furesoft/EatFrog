using EatFrog.Validation.Builder;

namespace EatFrog.Validation.Rules;

internal class SingleOperandValidatorRule<TOpcode> : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly int _operandIndex;
    private readonly Action<IOperandValidationRuleBuilder> _builder;

    public SingleOperandValidatorRule(int operandIndex, Action<IOperandValidationRuleBuilder> builder)
    {
        _operandIndex = operandIndex;
        _builder = builder;
    }
    
    public override bool Validate(Instruction<TOpcode> instruction)
    {
        var opValidatorBuilder = new OperandValidationRuleBuilder();

        _builder(opValidatorBuilder);

        if (_operandIndex >= instruction.Operands.Length)
        {
            return false;
        }

        return opValidatorBuilder.Validate(instruction.Operands[_operandIndex]);
    }
}