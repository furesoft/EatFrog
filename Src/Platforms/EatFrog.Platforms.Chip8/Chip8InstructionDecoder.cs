using EatFrog.Operands;
using Syroot.BinaryData;

namespace EatFrog.Platforms.Chip8;

public class Chip8InstructionDecoder : InstructionDecoder<Chip8OpCode>
{
    public override Instruction<Chip8OpCode> Decode(BinaryStream reader)
    {
        // Read two bytes from the stream
        byte highByte = (byte)reader.ReadByte();
        byte lowByte = (byte)reader.ReadByte();
        ushort opcode = (ushort)((highByte << 8) | lowByte);

        // Decode the opcode and operands
        Chip8OpCode chip8Opcode = DecodeOpcode(opcode);
        Operand[] operands = DecodeOperands(chip8Opcode, opcode);

        return new Instruction<Chip8OpCode>(chip8Opcode, operands);
    }

    private static Chip8OpCode DecodeOpcode(ushort opcode)
    {
        return (opcode & 0xF000) switch
        {
            0x0000 => (opcode & 0x00FF) switch
            {
                0x00E0 => Chip8OpCode.CLS,
                0x00EE => Chip8OpCode.RET,
                _ => Chip8OpCode.SYS,
            },
            0x1000 => Chip8OpCode.JP,
            0x2000 => Chip8OpCode.CALL,
            0x3000 => Chip8OpCode.SE_VX_NN,
            0x4000 => Chip8OpCode.SNE_VX_NN,
            0x5000 => Chip8OpCode.SE_VX_VY,
            0x6000 => Chip8OpCode.LD_VX_NN,
            0x7000 => Chip8OpCode.ADD_VX_NN,
            0x8000 => (opcode & 0x000F) switch
            {
                0x0000 => Chip8OpCode.LD_VX_VY,
                0x0001 => Chip8OpCode.OR_VX_VY,
                0x0002 => Chip8OpCode.AND_VX_VY,
                0x0003 => Chip8OpCode.XOR_VX_VY,
                0x0004 => Chip8OpCode.ADD_VX_VY,
                0x0005 => Chip8OpCode.SUB_VX_VY,
                0x0006 => Chip8OpCode.SHR_VX,
                0x0007 => Chip8OpCode.SUBN_VX_VY,
                0x000E => Chip8OpCode.SHL_VX,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            0x9000 => Chip8OpCode.SNE_VX_VY,
            0xA000 => Chip8OpCode.LD_I_NNN,
            0xB000 => Chip8OpCode.JP_V0_NNN,
            0xC000 => Chip8OpCode.RND_VX_NN,
            0xD000 => Chip8OpCode.DRW_VX_VY_N,
            0xE000 => (opcode & 0x00FF) switch
            {
                0x009E => Chip8OpCode.SKP_VX,
                0x00A1 => Chip8OpCode.SKNP_VX,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            0xF000 => (opcode & 0x00FF) switch
            {
                0x0007 => Chip8OpCode.LD_VX_DT,
                0x000A => Chip8OpCode.LD_VX_K,
                0x0015 => Chip8OpCode.LD_DT_VX,
                0x0018 => Chip8OpCode.LD_ST_VX,
                0x001E => Chip8OpCode.ADD_I_VX,
                0x0029 => Chip8OpCode.LD_F_VX,
                0x0033 => Chip8OpCode.LD_B_VX,
                0x0055 => Chip8OpCode.LD_I_VX,
                0x0065 => Chip8OpCode.LD_VX_I,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
        };
    }

    private Operand[] DecodeOperands(Chip8OpCode opcode, ushort rawOpcode)
    {
        // Decode operands based on opcode type
        return opcode switch
        {
            Chip8OpCode.JP or Chip8OpCode.CALL or Chip8OpCode.LD_I_NNN or Chip8OpCode.JP_V0_NNN => [new Address((ushort)(rawOpcode & 0x0FFF))],
            Chip8OpCode.SE_VX_NN or Chip8OpCode.SNE_VX_NN or Chip8OpCode.LD_VX_NN or Chip8OpCode.ADD_VX_NN or Chip8OpCode.RND_VX_NN => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new Value((byte)(rawOpcode & 0x00FF))],
            Chip8OpCode.SE_VX_VY or Chip8OpCode.LD_VX_VY or Chip8OpCode.OR_VX_VY or Chip8OpCode.AND_VX_VY or Chip8OpCode.XOR_VX_VY or Chip8OpCode.ADD_VX_VY or Chip8OpCode.SUB_VX_VY or Chip8OpCode.SUBN_VX_VY or Chip8OpCode.SNE_VX_VY => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4))],
            Chip8OpCode.SHR_VX or Chip8OpCode.SHL_VX or Chip8OpCode.SKP_VX or Chip8OpCode.SKNP_VX or Chip8OpCode.LD_VX_DT or Chip8OpCode.LD_VX_K or Chip8OpCode.LD_DT_VX or Chip8OpCode.LD_ST_VX or Chip8OpCode.ADD_I_VX or Chip8OpCode.LD_F_VX or Chip8OpCode.LD_B_VX or Chip8OpCode.LD_I_VX or Chip8OpCode.LD_VX_I => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8))],
            Chip8OpCode.DRW_VX_VY_N => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4)), new Value((byte)(rawOpcode & 0x000F))],
            Chip8OpCode.CLS or Chip8OpCode.RET => [],
            _ => throw new InvalidOperationException($"Unknown operand for opcode decoding: {opcode}"),
        };
    }
}