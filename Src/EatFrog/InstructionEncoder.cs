using Syroot.BinaryData;

namespace EatFrog;

public abstract class InstructionEncoder<TOpcode>
    where TOpcode : struct
{
    public abstract bool Encode(Instruction<TOpcode> instruction, BinaryStream writer);
}