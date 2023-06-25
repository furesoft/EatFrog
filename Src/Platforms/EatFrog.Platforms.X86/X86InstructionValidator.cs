using EatFrog.Operands;
using EatFrog.Validation;
using EatFrog.Validation.Builder.BuilderExtensions;

namespace EatFrog.Platforms.X86;

public class X86InstructionValidator : InstructionValidator<X86Opcode>
{
    public X86InstructionValidator()
    {
        For(X86Opcode.RET).NoOperands();
        
        For(X86Opcode.PUSH).Operands(_ => _.Kinds<Value, RegisterRef<X86Register>>());
        For(X86Opcode.POP).Operands(_ => _.Kinds<RegisterRef<X86Register>>());
        
        For(X86Opcode.MOV).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.ADD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.SUB).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        
        For(X86Opcode.AND).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.OR).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.XOR).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        
        For(X86Opcode.CMP).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        
        For(X86Opcode.JMP).Operands( _ => _.Kinds<Offset>());
        For(X86Opcode.JZ).Operands( _ => _.Kinds<Offset>());
        For(X86Opcode.JNZ).Operands( _ => _.Kinds<Offset>());
        
        For(X86Opcode.CALL).Operands( _ => _.Kinds<Offset>());
        
        For(X86Opcode.INC).Operands( _ => _.Kinds<RegisterRef<X86Register>>());
        For(X86Opcode.DEC).Operands( _ => _.Kinds<RegisterRef<X86Register>>());
        
        For(X86Opcode.MUL).Operands(_ => _.Kinds<RegisterRef<X86Register>, Value>());
        For(X86Opcode.DIV).Operands(_ => _.Kinds<RegisterRef<X86Register>, Value>());
        
        For(X86Opcode.NOT).Operands(_ => _.Kinds<RegisterRef<X86Register>>());
        
        For(X86Opcode.SHR).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.SHL).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        
        For(X86Opcode.NOP).NoOperands();
        For(X86Opcode.LEA).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.TEST).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.XCHG).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<Address, RegisterRef<X86Register>>()
        );
        
        For(X86Opcode.ADC).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.SBB).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, Value>(),
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>()
        );
        For(X86Opcode.NEG).Operands(_ => _.Kinds<RegisterRef<X86Register>>());
        
        For(X86Opcode.LOOP).Operands(_ => _.Kinds<Offset>());
        For(X86Opcode.CMPXCHG).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<Address, RegisterRef<X86Register>>()
        );
        For(X86Opcode.BSF).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.BSR).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.DIVSD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.MULSD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.COMISD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.UCOMISD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        
        For(X86Opcode.SQRTSD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.CVTSI2SD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.CVTSD2SI).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        For(X86Opcode.CVTTSD2SI).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
        
        For(X86Opcode.MOVSD).Operands(
            _ => _.Kinds<RegisterRef<X86Register>, RegisterRef<X86Register>>(),
            _ => _.Kinds<RegisterRef<X86Register>, Address>()
        );
    }
}