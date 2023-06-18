using Syroot.BinaryData;

namespace EatFrog.Platforms.X86;

public class X86InstructionEncoder : InstructionEncoder<X86Opcode>
{
    public override bool Encode(Instruction<X86Opcode> instruction, BinaryStream writer)
    {
        throw new NotImplementedException();
    }
}