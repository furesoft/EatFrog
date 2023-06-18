﻿using Syroot.BinaryData.Core;

namespace EatFrog.Platforms.X86;

public class X86Emitter : BytecodeEmitter<X86InstructionEncoder, X86InstructionValidator, 
    X86Opcode, X86Register, X86AddressEncoder>
{
    public X86Emitter(Stream target) : base(target, Endian.Little)
    {
    }

    public override ulong StackStartAddress { get; }
}