using Syroot.BinaryData.Core;

namespace EatFrog.Platforms.Chip8;

public class Chip8Maschine : Maschine<Chip8Opcode, Chip8Register, Chip8InstructionDecoder, Chip8InstructionEncoder, Chip8InstructionValidator, Chip8AddressEncoder>
{
    public Chip8Maschine() : base(Endian.Big)
    {
    }
}
