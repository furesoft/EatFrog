using EatFrog.Operands;
using EatFrog.Validation;
using EatFrog.Validation.Builder.BuilderExtensions;

namespace EatFrog.Platforms.Chip8
{
    public class Chip8InstructionValidator : InstructionValidator<Chip8Opcode>
    {
        public Chip8InstructionValidator()
        {
            For(Chip8Opcode.CLS).NoOperands();
            For(Chip8Opcode.RET).NoOperands();
            For(Chip8Opcode.JP).Operands(_ => _.Kinds<Address>());
            For(Chip8Opcode.CALL).Operands(_ => _.Kinds<Address>());
            For(Chip8Opcode.SE_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.SNE_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.SE_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.ADD_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.LD_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.OR_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.AND_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.XOR_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.ADD_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SUB_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SHR_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SUBN_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SHL_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SNE_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_I_NNN).Operands(_ => _.Kinds<Address>());
            For(Chip8Opcode.JP_V0_NNN).Operands(_ => _.Kinds<Address>());
            For(Chip8Opcode.RND_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.DRW_VX_VY_N).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>, Value>());
            For(Chip8Opcode.SKP_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.SKNP_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_VX_DT).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_VX_K).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_DT_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_ST_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.ADD_I_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_F_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_B_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_I_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8Opcode.LD_VX_I).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
        }
    }
}
