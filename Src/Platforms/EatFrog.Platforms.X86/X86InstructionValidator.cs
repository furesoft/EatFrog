using EatFrog.Operands;
using EatFrog.Validation;
using EatFrog.Validation.Builder.BuilderExtensions;

namespace EatFrog.Platforms.X86;

public class X86InstructionValidator : InstructionValidator<X86Opcode>
{
    public X86InstructionValidator()
    {
        For(X86Opcode.RET).NoOperands();
        For(X86Opcode.PUSH).OpCount(1).Operand(0,  _=> 
                _.Kinds<Value, RegisterRef<X86Register>>()
        );
    }
}