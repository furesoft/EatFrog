using EatFrog.Validation;

namespace EatFrog;

public abstract class BytecodeEmitter<TEncoder, TOpcode, TValidator>
    where TEncoder : InstructionEncoder<TOpcode>, new()
    where TOpcode : struct
    where TValidator : InstructionValidator<TOpcode>, new()
{
    private readonly TEncoder _encoder = new();
    private readonly TValidator _validator = new();
    
    public abstract ulong StackStartAddress { get; }

    public bool Emit(Stream target, IEnumerable<Instruction<TOpcode>> instructions)
    {
        using var binaryWriter = new BinaryWriter(target);

        foreach (var instruction in instructions)
        {
            if (!_encoder.Encode(instruction, binaryWriter))
            {
                return false;
            }
        }
        
        return true;
    }
}