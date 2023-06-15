namespace EatFrog;

public abstract class BytecodeEmitter<TEncoder, TOpcode>
    where TEncoder : InstructionEncoder<TOpcode>, new()
    where TOpcode : struct
{
    public abstract ulong StackStartAddress { get; }

    public bool Emit(Stream target, IEnumerable<Instruction<TOpcode>> instructions)
    {
        var encoder = new TEncoder();
        using var binaryWriter = new BinaryWriter(target);

        foreach (var instruction in instructions)
        {
            if (!encoder.Encode(instruction, binaryWriter))
            {
                return false;
            }
        }
        
        return true;
    }
}