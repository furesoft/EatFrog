using EatFrog.Operands;
using EatFrog.Validation;
using EatFrog.Validation.Builder.BuilderExtensions;

namespace EatFrog.Platforms.Chip8
{
    public class Chip8InstructionValidator : InstructionValidator<Chip8OpCode>
    {
        public Chip8InstructionValidator()
        {
            For(Chip8OpCode.CLS).NoOperands();
            For(Chip8OpCode.RET).NoOperands();
            For(Chip8OpCode.JP).Operands(_ => _.Kinds<Address>());
            For(Chip8OpCode.CALL).Operands(_ => _.Kinds<Address>());
            For(Chip8OpCode.SE_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.SNE_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.SE_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.ADD_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.LD_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.OR_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.AND_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.XOR_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.ADD_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SUB_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SHR_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SUBN_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SHL_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SNE_VX_VY).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_I_NNN).Operands(_ => _.Kinds<Address>());
            For(Chip8OpCode.JP_V0_NNN).Operands(_ => _.Kinds<Address>());
            For(Chip8OpCode.RND_VX_NN).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.DRW_VX_VY_N).Operands(_ => _.Kinds<RegisterRef<Chip8Register>, RegisterRef<Chip8Register>, Value>());
            For(Chip8OpCode.SKP_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.SKNP_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_VX_DT).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_VX_K).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_DT_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_ST_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.ADD_I_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_F_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_B_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_I_VX).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
            For(Chip8OpCode.LD_VX_I).Operands(_ => _.Kinds<RegisterRef<Chip8Register>>());
        }
    }
}
