namespace EatFrog;

public abstract class InstructionEncoder<T>
{
    public abstract bool Encode(Instruction<T> instruction, BinaryWriter writer);
}