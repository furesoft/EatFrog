using Syroot.BinaryData;

namespace EatFrog.Platforms.X86;

public class X86InstructionDecoder : InstructionDecoder<X86Opcode>
{
    public override Instruction<X86Opcode> Decode(BinaryStream reader)
    {
        throw new NotImplementedException();
    }
}