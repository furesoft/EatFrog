namespace EatFrog.Validation;

public class InstructionValidatorBuilder<TOpcode> : IInstructionValidatorBuilder<TOpcode>
    where TOpcode : struct
{
    private readonly TOpcode _opcode;
    private readonly Dictionary<TOpcode, InstructionValidatorRule<TOpcode>> _rules;
    private InstructionValidatorRule<TOpcode> _rule;

    public InstructionValidatorBuilder(TOpcode opcode, Dictionary<TOpcode, InstructionValidatorRule<TOpcode>> rules)
    {
        _opcode = opcode;
        _rules = rules;
    }

    public IInstructionValidatorBuilder<TOpcode> AddRule(InstructionValidatorRule<TOpcode> rule)
    {
        if (_rule == null)
        {
            _rule = rule;
            _rules.Add(_opcode, _rule);
        }
        else
        {
            _rule = new CascadeValidatorRule<TOpcode>(_rule, rule);
            _rules[_opcode] = _rule;
        }

        return this;
    }
}