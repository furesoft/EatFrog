namespace EatFrog;

public abstract class InstructionDecoder<TOpcode>
    where TOpcode : struct
{
    public abstract Instruction<TOpcode> Decode(BinaryReader reader);
}