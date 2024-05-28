using EatFrog.Validation.Rules;

namespace EatFrog.Validation.Builder;

public class InstructionValidatorBuilder<TOpcode>(TOpcode opcode, Dictionary<TOpcode, InstructionValidatorRule<TOpcode>> rules) : IInstructionValidatorBuilder<TOpcode>
    where TOpcode : struct
{
    private readonly TOpcode _opcode = opcode;
    private readonly Dictionary<TOpcode, InstructionValidatorRule<TOpcode>> _rules = rules;
    private InstructionValidatorRule<TOpcode> _rule;

    public IInstructionValidatorBuilder<TOpcode> AddRule(InstructionValidatorRule<TOpcode> rule)
    {
        if (_rule == null)
        {
            _rule = rule;
            _rules.Add(_opcode, _rule);
        }
        else
        {
            _rule = new ConjunctionValidatorRule<TOpcode>(_rule, rule);
            _rules[_opcode] = _rule;
        }

        return this;
    }
}