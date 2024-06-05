using EatFrog.Assembler.MacroSystem;
using EatFrog.Validation;
using Furesoft.PrattParser;
using Syroot.BinaryData.Core;

namespace EatFrog;

public abstract class RegisterMaschine<TOpCode, TRegister, TInstructionDecoder, TInstructionEncoder, TInstructionValidator, TAddressEncoder, TMacroStorage>(Endian endian)
    where TOpCode : struct
    where TRegister : struct
    where TInstructionDecoder : InstructionDecoder<TOpCode>, new()
    where TInstructionEncoder : InstructionEncoder<TOpCode>, new()
    where TInstructionValidator : InstructionValidator<TOpCode>, new()
    where TAddressEncoder : IAddressEncoder, new()
    where TMacroStorage : MacroStorage<TOpCode, TRegister>, new()
{
    public TInstructionDecoder InstructionDecoder = new();
    public TInstructionEncoder InstructionEncoder = new();

    public BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder> Emitter = new(endian);
    public Endian Endian = endian;

    public TranslationUnit Parse(string src, string filename = "test.dsl")
    {
        return Parser.Parse<Assembler.Core.AssemblyParser<TOpCode, TRegister, TMacroStorage>>(src, filename, useStatementsAtToplevel: true);
    }

    public IEnumerable<Instruction<TOpCode>> FromAssembler(string src, string filename = "test.dsl")
    {
        var translationUnit = Parser.Parse<Assembler.Core.AssemblyParser<TOpCode, TRegister, TMacroStorage>>(src, filename, useStatementsAtToplevel: true);


        var instructionConversionVisiter = 
                new InstructionConversionVisitor<TOpCode, TRegister, TMacroStorage>(Assembler.Core.AssemblyParser<TOpCode, TRegister, TMacroStorage>.MacroExpander);

        return translationUnit.Tree.Accept(instructionConversionVisiter);
    }

    public BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder> NewEmitter(Stream strm)
    {
        var emitter = (BytecodeEmitter<TInstructionEncoder, TInstructionValidator, TOpCode, TRegister, TAddressEncoder>)Activator.CreateInstance(Emitter.GetType(), Endian);

        emitter.SetTarget(strm);

        return emitter;
    }
}
