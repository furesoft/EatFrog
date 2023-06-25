namespace EatFrog.Platforms.X86;

public enum X86Opcode
{
    MOV = 0x89,         // Move
    ADD = 0x03,         // Add
    SUB = 0x2B,         // Subtract
    AND = 0x21,         // Bitwise AND
    OR = 0x0B,          // Bitwise OR
    XOR = 0x33,         // Bitwise XOR
    CMP = 0x3B,         // Compare
    JMP = 0xE9,         // Unconditional Jump
    JZ = 0x74,          // Jump if Zero
    JNZ = 0x75,         // Jump if Not Zero
    CALL = 0xE8,        // Call Procedure
    RET = 0xC3,         // Return from Procedure
    PUSH = 0x50,        // Push onto Stack
    POP = 0x58,         // Pop from Stack
    INC = 0xFF,         // Increment
    DEC = 0xFF,         // Decrement
    MUL = 0xF7,         // Unsigned Multiply
    DIV = 0xF7,         // Unsigned Divide
    NOT = 0xF7,         // Bitwise NOT
    SHR = 0xD1,         // Shift Right
    SHL = 0xD1,         // Shift Left
    NOP = 0x90,         // No Operation
    LEA = 0x8D,         // Load Effective Address
    TEST = 0x85,        // Logical AND
    XCHG = 0x87,        // Exchange Register/Memory with Register
    ADC = 0x11,         // Add with Carry
    SBB = 0x19,         // Subtract with Borrow
    NEG = 0xF7,         // Two's Complement Negation
    LOOP = 0xE2,        // Loop with Counter
    CMPXCHG = 0x0F_B0,  // Compare and Exchange
    BSF = 0x0F_BC,      // Bit Scan Forward
    BSR = 0x0F_BD,      // Bit Scan Reverse
    DIVSD = 0xF2_0F_5E, // Scalar Double-Precision Divide
    MULSD = 0xF2_0F_59, // Scalar Double-Precision Multiply
    COMISD = 0x0F_2F,   // Compare Scalar Ordered Double-Precision Floating-Point Values
    UCOMISD = 0x0F_2E,  // Unordered Compare Scalar Double-Precision Floating-Point Values
    SQRTSD = 0xF2_0F_51, // Scalar Double-Precision Square Root
    CVTSI2SD = 0xF2_0F_2A, // Convert Scalar Doubleword Integer to Scalar Double-Precision Floating-Point Value
    CVTSD2SI = 0xF2_0F_2D, // Convert Scalar Double-Precision Floating-Point Value to Scalar Doubleword Integer
    CVTTSD2SI = 0xF2_0F_2C, // Convert with Truncation Scalar Double-Precision Floating-Point Value to Scalar Doubleword Integer
    MOVSD = 0xF2_0F_10 // Move Scalar Double-Precision Floating-Point
}