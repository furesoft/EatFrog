using EatFrog.Operands;
using EatFrog.Validation;

namespace EatFrog;

public abstract class BytecodeEmitter<TEncoder, TValidator, TOpcode, TRegister> : IDisposable
    where TEncoder : InstructionEncoder<TOpcode>, new()
    where TOpcode : struct
    where TRegister : struct
    where TValidator : InstructionValidator<TOpcode>, new()
{
    private readonly TEncoder _encoder = new();
    private readonly TValidator _validator = new();
    private readonly Dictionary<string, ulong> _labels = new();
    private BinaryWriter _writer;
    private bool _isClosed = false;

    public abstract ulong StackStartAddress { get; }

    public BytecodeEmitter(Stream target)
    {
        _writer = new(target);
    }

    ~BytecodeEmitter()
    {
        if (!_isClosed)
        {
            throw new EmiterNotClosedException();
        }
    }

    public LabelRef CreateLabel(string name)
    {
        var lbl = new LabelRef(name);
        _labels.Add(lbl.Name, (ulong) _writer.BaseStream.Position);

        return lbl;
    }

    public bool Emit(Instruction<TOpcode> instruction)
    {
        if (!_validator.Validate(instruction))
        {
            return false;
        }
        
        if (!_encoder.Encode(instruction, _writer))
        {
            return false;
        }

        return true;
    }

    public void Dispose()
    {
        _writer?.Dispose();
        _isClosed = true;
    }
}