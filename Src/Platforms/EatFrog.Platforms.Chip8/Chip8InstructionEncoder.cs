using Syroot.BinaryData;

namespace EatFrog.Platforms.Chip8;

public class Chip8InstructionEncoder : InstructionEncoder<Chip8Opcode>
{
    public override bool Encode(Instruction<Chip8Opcode> instruction, BinaryStream writer)
    {
        throw new NotImplementedException();
    }
}
