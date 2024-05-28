using EatFrog.Operands;
using EatFrog.Validation;
using Syroot.BinaryData;
using Syroot.BinaryData.Core;

namespace EatFrog;

public class BytecodeEmitter<TEncoder, TValidator, TOpcode, TRegister, TAddressEncoder>(Endian endian) : IDisposable
    where TEncoder : InstructionEncoder<TOpcode>, new()
    where TOpcode : struct
    where TRegister : struct
    where TValidator : InstructionValidator<TOpcode>, new()
    where TAddressEncoder : IAddressEncoder, new()
{
    private readonly TEncoder _encoder = new();
    private readonly TAddressEncoder _addressEncoder = new();
    private readonly TValidator _validator = new();
    private readonly Dictionary<string, ulong> _labels = new();
    private readonly Endian endian = endian;
    private BinaryStream _writer;
    private bool _isClosed = false;

    public ulong StackStartAddress { get; set; }

    public void SetTarget(Stream target) {
        _writer = new(target)
        {
            ByteConverter = endian == Endian.Little ? ByteConverter.Little : ByteConverter.Big
        };
    }

    /// <summary>
    /// Ensures that the labels can be fixed in second run later
    /// </summary>
    /// <exception cref="EmiterNotClosedException"></exception>
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
        if (!_validator.Validate(instruction).IsSuccess)
        {
            return false;
        }
        
        if (!_encoder.Encode(instruction, _writer))
        {
            return false;
        }

        return true;
    }

    public bool Emit(TOpcode opcode)
    {
        return Emit(new Instruction<TOpcode>(opcode));
    }
    
    public bool Emit(TOpcode opcode, params Operand[] operands)
    {
        return Emit(new Instruction<TOpcode>(opcode){ Operands = operands});
    }

    public void Dispose()
    {
        _writer?.Dispose();
        _isClosed = true;
    }
}