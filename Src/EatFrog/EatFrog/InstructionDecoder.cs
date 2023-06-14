namespace EatFrog;

public abstract class InstructionDecoder<T>
{
    public abstract Instruction<T> Decode(BinaryReader reader);
}