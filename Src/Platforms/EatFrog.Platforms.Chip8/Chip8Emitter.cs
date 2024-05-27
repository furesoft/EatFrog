using Syroot.BinaryData.Core;

namespace EatFrog.Platforms.Chip8;

public class Chip8Emitter(Stream target) : BytecodeEmitter<Chip8InstructionEncoder, Chip8InstructionValidator, 
    Chip8Opcode, Chip8Register, Chip8AddressEncoder>(target, Endian.Big)
{
    public override ulong StackStartAddress { get; }
}