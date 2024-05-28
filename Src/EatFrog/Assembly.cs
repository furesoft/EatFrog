namespace EatFrog;

public abstract class Assembly<TOpCode, TRegister, TInstructionDecoder, TInstructionEncoder>
    where TOpCode : struct
    where TRegister : struct
    where TInstructionDecoder : InstructionDecoder<TOpCode>, new()
    where TInstructionEncoder : InstructionEncoder<TOpCode>, new()
{
    protected TInstructionDecoder instructionDecoder = new();
    protected TInstructionEncoder instructionEncoder = new();

    public abstract Assembly<TOpCode, TRegister, TInstructionDecoder, TInstructionEncoder> Load(Stream strm);
    public abstract void Save(Stream strm);

    public static Assembly<TOpCode, TRegister, TInstructionDecoder, TInstructionEncoder> FromString(string str)
    {
        var parser = new Assembler.Core.AssemblyParser<TOpCode, TRegister>();

        //Todo: implement loading from assembly string
        return null;
    }

}