using EatFrog.Operands;
using Syroot.BinaryData;

namespace EatFrog.Platforms.Chip8;

public class Chip8InstructionDecoder : InstructionDecoder<Chip8Opcode>
{
    public override Instruction<Chip8Opcode> Decode(BinaryStream reader)
    {
        // Read two bytes from the stream
        byte highByte = (byte)reader.ReadByte();
        byte lowByte = (byte)reader.ReadByte();
        ushort opcode = (ushort)((highByte << 8) | lowByte);

        // Decode the opcode and operands
        Chip8Opcode chip8Opcode = DecodeOpcode(opcode);
        Operand[] operands = DecodeOperands(chip8Opcode, opcode);

        return new Instruction<Chip8Opcode>(chip8Opcode, operands);
    }

    private static Chip8Opcode DecodeOpcode(ushort opcode)
    {
        switch (opcode & 0xF000)
        {
            case 0x0000:
                switch (opcode & 0x00FF)
                {
                    case 0x00E0: return Chip8Opcode.CLS;
                    case 0x00EE: return Chip8Opcode.RET;
                    default: return Chip8Opcode.SYS;
                }
            case 0x1000: return Chip8Opcode.JP;
            case 0x2000: return Chip8Opcode.CALL;
            case 0x3000: return Chip8Opcode.SE_VX_NN;
            case 0x4000: return Chip8Opcode.SNE_VX_NN;
            case 0x5000: return Chip8Opcode.SE_VX_VY;
            case 0x6000: return Chip8Opcode.LD_VX_NN;
            case 0x7000: return Chip8Opcode.ADD_VX_NN;
            case 0x8000:
                switch (opcode & 0x000F)
                {
                    case 0x0000: return Chip8Opcode.LD_VX_VY;
                    case 0x0001: return Chip8Opcode.OR_VX_VY;
                    case 0x0002: return Chip8Opcode.AND_VX_VY;
                    case 0x0003: return Chip8Opcode.XOR_VX_VY;
                    case 0x0004: return Chip8Opcode.ADD_VX_VY;
                    case 0x0005: return Chip8Opcode.SUB_VX_VY;
                    case 0x0006: return Chip8Opcode.SHR_VX;
                    case 0x0007: return Chip8Opcode.SUBN_VX_VY;
                    case 0x000E: return Chip8Opcode.SHL_VX;
                    default: throw new InvalidOperationException($"Unknown opcode: {opcode:X4}");
                }
            case 0x9000: return Chip8Opcode.SNE_VX_VY;
            case 0xA000: return Chip8Opcode.LD_I_NNN;
            case 0xB000: return Chip8Opcode.JP_V0_NNN;
            case 0xC000: return Chip8Opcode.RND_VX_NN;
            case 0xD000: return Chip8Opcode.DRW_VX_VY_N;
            case 0xE000:
                switch (opcode & 0x00FF)
                {
                    case 0x009E: return Chip8Opcode.SKP_VX;
                    case 0x00A1: return Chip8Opcode.SKNP_VX;
                    default: throw new InvalidOperationException($"Unknown opcode: {opcode:X4}");
                }
            case 0xF000:
                switch (opcode & 0x00FF)
                {
                    case 0x0007: return Chip8Opcode.LD_VX_DT;
                    case 0x000A: return Chip8Opcode.LD_VX_K;
                    case 0x0015: return Chip8Opcode.LD_DT_VX;
                    case 0x0018: return Chip8Opcode.LD_ST_VX;
                    case 0x001E: return Chip8Opcode.ADD_I_VX;
                    case 0x0029: return Chip8Opcode.LD_F_VX;
                    case 0x0033: return Chip8Opcode.LD_B_VX;
                    case 0x0055: return Chip8Opcode.LD_I_VX;
                    case 0x0065: return Chip8Opcode.LD_VX_I;
                    default: throw new InvalidOperationException($"Unknown opcode: {opcode:X4}");
                }
            default: throw new InvalidOperationException($"Unknown opcode: {opcode:X4}");
        }
    }

    private Operand[] DecodeOperands(Chip8Opcode opcode, ushort rawOpcode)
    {
        // Decode operands based on opcode type
        switch (opcode)
        {
            case Chip8Opcode.JP:
            case Chip8Opcode.CALL:
            case Chip8Opcode.LD_I_NNN:
            case Chip8Opcode.JP_V0_NNN:
                return new Operand[] { new Address((ushort)(rawOpcode & 0x0FFF)) };

            case Chip8Opcode.SE_VX_NN:
            case Chip8Opcode.SNE_VX_NN:
            case Chip8Opcode.LD_VX_NN:
            case Chip8Opcode.ADD_VX_NN:
            case Chip8Opcode.RND_VX_NN:
                return new Operand[] { new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new Value((byte)(rawOpcode & 0x00FF)) };

            case Chip8Opcode.SE_VX_VY:
            case Chip8Opcode.LD_VX_VY:
            case Chip8Opcode.OR_VX_VY:
            case Chip8Opcode.AND_VX_VY:
            case Chip8Opcode.XOR_VX_VY:
            case Chip8Opcode.ADD_VX_VY:
            case Chip8Opcode.SUB_VX_VY:
            case Chip8Opcode.SUBN_VX_VY:
            case Chip8Opcode.SNE_VX_VY:
                return new Operand[] { new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4)) };

            case Chip8Opcode.SHR_VX:
            case Chip8Opcode.SHL_VX:
            case Chip8Opcode.SKP_VX:
            case Chip8Opcode.SKNP_VX:
            case Chip8Opcode.LD_VX_DT:
            case Chip8Opcode.LD_VX_K:
            case Chip8Opcode.LD_DT_VX:
            case Chip8Opcode.LD_ST_VX:
            case Chip8Opcode.ADD_I_VX:
            case Chip8Opcode.LD_F_VX:
            case Chip8Opcode.LD_B_VX:
            case Chip8Opcode.LD_I_VX:
            case Chip8Opcode.LD_VX_I:
                return new Operand[] { new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)) };

            case Chip8Opcode.DRW_VX_VY_N:
                return new Operand[] { new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4)), new Value((byte)(rawOpcode & 0x000F)) };

            case Chip8Opcode.CLS:
            case Chip8Opcode.RET:
                return Array.Empty<Operand>();

            default:
                throw new InvalidOperationException($"Unknown opcode for operand decoding: {opcode}");
        }
    }
}