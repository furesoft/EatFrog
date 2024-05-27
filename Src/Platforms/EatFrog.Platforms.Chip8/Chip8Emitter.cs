using Syroot.BinaryData.Core;

namespace EatFrog.Platforms.Chip8;

public class Chip8Emitter : BytecodeEmitter<Chip8InstructionEncoder, Chip8InstructionValidator, 
    Chip8Opcode, Chip8Register, Chip8AddressEncoder>
{
    public Chip8Emitter(Stream target) : base(target, Endian.Big)
    {
    }

    public override ulong StackStartAddress { get; }
}