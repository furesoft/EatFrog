using EatFrog.Assembler.MacroSystem;
using EatFrog.Operands;
using Syroot.BinaryData.Core;

namespace EatFrog.Platforms.Chip8;

public class Chip8Maschine : RegisterMaschine<Chip8OpCode, Chip8Register, Chip8InstructionDecoder,
    Chip8InstructionEncoder, Chip8InstructionValidator, Chip8AddressEncoder, Chip8MacroStorage>
{
    public Chip8Maschine() : base(Endian.Big)
    {
    }
}

public class Chip8MacroStorage : MacroStorage<Chip8OpCode, Chip8Register>
{
    public Chip8MacroStorage()
    {
        AddMacro(new AddMacro());
    }
}

class AddMacro : MacroDefinition<Chip8OpCode, Chip8Register>
{
    public override string Name => "add";

    public override Instruction<Chip8OpCode>[] Expand(Operand[] args)
    {
        if (args[0] is RegisterRef<Chip8Register> r1 && args[0] is RegisterRef<Chip8Register> r2)
        {
            Chip8OpCode opcode = Chip8OpCode.CLS;
            if (r1.Register == Chip8Register.I && r2.Register == Chip8Register.V0) {
                opcode = Chip8OpCode.ADD_I_VX;
            }

            return [new Instruction<Chip8OpCode>(opcode, args)];
        }

        return [];
    }
}