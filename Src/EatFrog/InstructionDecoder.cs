using Syroot.BinaryData;

namespace EatFrog;

public abstract class InstructionDecoder<TOpcode>
    where TOpcode : struct
{
    public abstract Instruction<TOpcode> Decode(BinaryStream reader);
}