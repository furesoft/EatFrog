using EatFrog.Validation.Builder;

namespace EatFrog.Validation.Rules;

internal class SingleOperandValidatorRule<TOpcode>(int operandIndex, Action<IOperandValidationRuleBuilder> builder) : InstructionValidatorRule<TOpcode>
    where TOpcode : struct
{
    private readonly int _operandIndex = operandIndex;
    private readonly Action<IOperandValidationRuleBuilder> _builder = builder;

    public override ValidationResult Validate(Instruction<TOpcode> instruction)
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