using EatFrog.Operands;
using Syroot.BinaryData;

namespace EatFrog.Platforms.Chip8;

public class Chip8InstructionEncoder : InstructionEncoder<Chip8OpCode>
{
    public override bool Encode(Instruction<Chip8OpCode> instruction, BinaryStream writer)
    {
        ushort opcode = 0;

        switch (instruction.Opcode)
        {
            case Chip8OpCode.CLS:
                opcode = 0x00E0;
                break;

            case Chip8OpCode.RET:
                opcode = 0x00EE;
                break;

            case Chip8OpCode.JP:
                if (instruction.Operands.Length == 1 && instruction.Operands[0] is Address address)
                {
                    opcode = (ushort)(0x1000 | (address.Value & 0x0FFF));
                }
                break;

            case Chip8OpCode.CALL:
                if (instruction.Operands.Length == 1 && instruction.Operands[0] is Address callAddress)
                {
                    opcode = (ushort)(0x2000 | (callAddress.Value & 0x0FFF));
                }
                break;

            default:
                throw new InvalidOperationException($"Unknown opcode: {instruction.Opcode}");
        }

        // Write the opcode to the binary stream
        writer.Write(opcode);
        return true;
    }
}