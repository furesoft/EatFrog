using EatFrog.Validation;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
using Syroot.BinaryData.Core;

namespace EatFrog;

public abstract class RegisterMaschine<TOpCode, TRegister, TInstructionDecoder, TInstructionEncoder, TInstructionValidator, TAddressEncoder>(Endian endian)
    where TOpCode : struct
    where TRegister : struct
    where TInstructionDecoder : InstructionDecoder<TOpCode>, new()
    where TInstructionEncoder : InstructionEncoder<TOpCode>, new()
    where TInstructionValidator : InstructionValidator<TOpCode>, new()
    where TAddressEncoder : IAddressEncoder, new()
{
    public TInstructionDecoder InstructionDecoder = new();
    public TInstructionEncoder InstructionEncoder = new();

    public BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder> Emitter = new(endian);
    public Endian Endian = endian;

    public TranslationUnit Parse(string src, string filename = "test.dsl")
    {
        return Parser.Parse<Assembler.Core.AssemblyParser<TOpCode, TRegister>>(src, filename, useToplevelStatements: true);
    }

    public BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder> NewEmitter(Stream strm)
    {
        var emitter = (BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder>)Activator.CreateInstance(Emitter.GetType(), Endian);

        emitter.SetTarget(strm);

        return emitter;
    }
}
