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
        return (opcode & 0xF000) switch
        {
            0x0000 => (opcode & 0x00FF) switch
            {
                0x00E0 => Chip8Opcode.CLS,
                0x00EE => Chip8Opcode.RET,
                _ => Chip8Opcode.SYS,
            },
            0x1000 => Chip8Opcode.JP,
            0x2000 => Chip8Opcode.CALL,
            0x3000 => Chip8Opcode.SE_VX_NN,
            0x4000 => Chip8Opcode.SNE_VX_NN,
            0x5000 => Chip8Opcode.SE_VX_VY,
            0x6000 => Chip8Opcode.LD_VX_NN,
            0x7000 => Chip8Opcode.ADD_VX_NN,
            0x8000 => (opcode & 0x000F) switch
            {
                0x0000 => Chip8Opcode.LD_VX_VY,
                0x0001 => Chip8Opcode.OR_VX_VY,
                0x0002 => Chip8Opcode.AND_VX_VY,
                0x0003 => Chip8Opcode.XOR_VX_VY,
                0x0004 => Chip8Opcode.ADD_VX_VY,
                0x0005 => Chip8Opcode.SUB_VX_VY,
                0x0006 => Chip8Opcode.SHR_VX,
                0x0007 => Chip8Opcode.SUBN_VX_VY,
                0x000E => Chip8Opcode.SHL_VX,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            0x9000 => Chip8Opcode.SNE_VX_VY,
            0xA000 => Chip8Opcode.LD_I_NNN,
            0xB000 => Chip8Opcode.JP_V0_NNN,
            0xC000 => Chip8Opcode.RND_VX_NN,
            0xD000 => Chip8Opcode.DRW_VX_VY_N,
            0xE000 => (opcode & 0x00FF) switch
            {
                0x009E => Chip8Opcode.SKP_VX,
                0x00A1 => Chip8Opcode.SKNP_VX,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            0xF000 => (opcode & 0x00FF) switch
            {
                0x0007 => Chip8Opcode.LD_VX_DT,
                0x000A => Chip8Opcode.LD_VX_K,
                0x0015 => Chip8Opcode.LD_DT_VX,
                0x0018 => Chip8Opcode.LD_ST_VX,
                0x001E => Chip8Opcode.ADD_I_VX,
                0x0029 => Chip8Opcode.LD_F_VX,
                0x0033 => Chip8Opcode.LD_B_VX,
                0x0055 => Chip8Opcode.LD_I_VX,
                0x0065 => Chip8Opcode.LD_VX_I,
                _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
            },
            _ => throw new InvalidOperationException($"Unknown opcode: {opcode:X4}"),
        };
    }

    private Operand[] DecodeOperands(Chip8Opcode opcode, ushort rawOpcode)
    {
        // Decode operands based on opcode type
        return opcode switch
        {
            Chip8Opcode.JP or Chip8Opcode.CALL or Chip8Opcode.LD_I_NNN or Chip8Opcode.JP_V0_NNN => [new Address((ushort)(rawOpcode & 0x0FFF))],
            Chip8Opcode.SE_VX_NN or Chip8Opcode.SNE_VX_NN or Chip8Opcode.LD_VX_NN or Chip8Opcode.ADD_VX_NN or Chip8Opcode.RND_VX_NN => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new Value((byte)(rawOpcode & 0x00FF))],
            Chip8Opcode.SE_VX_VY or Chip8Opcode.LD_VX_VY or Chip8Opcode.OR_VX_VY or Chip8Opcode.AND_VX_VY or Chip8Opcode.XOR_VX_VY or Chip8Opcode.ADD_VX_VY or Chip8Opcode.SUB_VX_VY or Chip8Opcode.SUBN_VX_VY or Chip8Opcode.SNE_VX_VY => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4))],
            Chip8Opcode.SHR_VX or Chip8Opcode.SHL_VX or Chip8Opcode.SKP_VX or Chip8Opcode.SKNP_VX or Chip8Opcode.LD_VX_DT or Chip8Opcode.LD_VX_K or Chip8Opcode.LD_DT_VX or Chip8Opcode.LD_ST_VX or Chip8Opcode.ADD_I_VX or Chip8Opcode.LD_F_VX or Chip8Opcode.LD_B_VX or Chip8Opcode.LD_I_VX or Chip8Opcode.LD_VX_I => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8))],
            Chip8Opcode.DRW_VX_VY_N => [new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x0F00) >> 8)), new RegisterRef<Chip8Register>((Chip8Register)((rawOpcode & 0x00F0) >> 4)), new Value((byte)(rawOpcode & 0x000F))],
            Chip8Opcode.CLS or Chip8Opcode.RET => [],
            _ => throw new InvalidOperationException($"Unknown operand for opcode decoding: {opcode}"),
        };
    }
}