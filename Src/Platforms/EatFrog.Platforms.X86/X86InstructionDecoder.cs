namespace EatFrog.Platforms.X86;

public class X86InstructionDecoder : InstructionDecoder<X86Opcode>
{
    public override Instruction<X86Opcode> Decode(BinaryReader reader)
    {
        throw new NotImplementedException();
    }
}