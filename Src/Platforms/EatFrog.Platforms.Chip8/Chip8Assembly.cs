using Syroot.BinaryData;

namespace EatFrog.Platforms.Chip8;

public class Chip8Assembly : Assembly<Chip8Opcode, Chip8InstructionDecoder, Chip8InstructionEncoder>
{
    public List<Instruction<Chip8Opcode>> Instructions { get; set; } = [];

    public override Chip8Assembly Load(Stream strm)
    {
        var reader = new BinaryStream(strm, ByteConverter.Big);

        while(reader.Position < strm.Length) {
            var instruction = instructionDecoder.Decode(reader);

            Instructions.Add(instruction);
        }

        return this;
    }

    public override void Save(Stream strm)
    {
        var emitter = new Chip8Emitter(strm);

        foreach (var instruction in Instructions) {
            emitter.Emit(instruction);
        }

        emitter.Dispose();
    }
}