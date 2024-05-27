namespace EatFrog.Platforms.Chip8;

public enum Chip8Opcode
{
    // 0x0NNN - Calls RCA 1802 program at address NNN (not implemented in most CHIP-8 interpreters)
    SYS = 0x0000,

    // 0x00E0 - Clears the screen
    CLS = 0x00E0,

    // 0x00EE - Returns from a subroutine
    RET = 0x00EE,

    // 0x1NNN - Jumps to address NNN
    JP = 0x1000,

    // 0x2NNN - Calls subroutine at NNN
    CALL = 0x2000,

    // 0x3XNN - Skips the next instruction if VX equals NN
    SE_VX_NN = 0x3000,

    // 0x4XNN - Skips the next instruction if VX does not equal NN
    SNE_VX_NN = 0x4000,

    // 0x5XY0 - Skips the next instruction if VX equals VY
    SE_VX_VY = 0x5000,

    // 0x6XNN - Sets VX to NN
    LD_VX_NN = 0x6000,

    // 0x7XNN - Adds NN to VX (carry flag is not changed)
    ADD_VX_NN = 0x7000,

    // 0x8XY0 - Sets VX to the value of VY
    LD_VX_VY = 0x8000,

    // 0x8XY1 - Sets VX to VX OR VY
    OR_VX_VY = 0x8001,

    // 0x8XY2 - Sets VX to VX AND VY
    AND_VX_VY = 0x8002,

    // 0x8XY3 - Sets VX to VX XOR VY
    XOR_VX_VY = 0x8003,

    // 0x8XY4 - Adds VY to VX (VF is set to 1 when there's a carry, and to 0 when there isn't)
    ADD_VX_VY = 0x8004,

    // 0x8XY5 - VY is subtracted from VX (VF is set to 0 when there's a borrow, and 1 when there isn't)
    SUB_VX_VY = 0x8005,

    // 0x8XY6 - Stores the least significant bit of VX in VF and then shifts VX to the right by 1
    SHR_VX = 0x8006,

    // 0x8XY7 - Sets VX to VY minus VX (VF is set to 0 when there's a borrow, and 1 when there isn't)
    SUBN_VX_VY = 0x8007,

    // 0x8XYE - Stores the most significant bit of VX in VF and then shifts VX to the left by 1
    SHL_VX = 0x800E,

    // 0x9XY0 - Skips the next instruction if VX doesn't equal VY
    SNE_VX_VY = 0x9000,

    // 0xANNN - Sets I to the address NNN
    LD_I_NNN = 0xA000,

    // 0xBNNN - Jumps to the address NNN plus V0
    JP_V0_NNN = 0xB000,

    // 0xCXNN - Sets VX to a random number and NN
    RND_VX_NN = 0xC000,

    // 0xDXYN - Draws a sprite at coordinate (VX, VY) with width 8 pixels and height N pixels
    DRW_VX_VY_N = 0xD000,

    // 0xEX9E - Skips the next instruction if the key stored in VX is pressed
    SKP_VX = 0xE09E,

    // 0xEXA1 - Skips the next instruction if the key stored in VX isn't pressed
    SKNP_VX = 0xE0A1,

    // 0xFX07 - Sets VX to the value of the delay timer
    LD_VX_DT = 0xF007,

    // 0xFX0A - A key press is awaited, and then stored in VX
    LD_VX_K = 0xF00A,

    // 0xFX15 - Sets the delay timer to VX
    LD_DT_VX = 0xF015,

    // 0xFX18 - Sets the sound timer to VX
    LD_ST_VX = 0xF018,

    // 0xFX1E - Adds VX to I
    ADD_I_VX = 0xF01E,

    // 0xFX29 - Sets I to the location of the sprite for the character in VX
    LD_F_VX = 0xF029,

    // 0xFX33 - Stores the Binary-coded decimal representation of VX at the addresses I, I plus 1, and I plus 2
    LD_B_VX = 0xF033,

    // 0xFX55 - Stores V0 to VX in memory starting at address I
    LD_I_VX = 0xF055,

    // 0xFX65 - Fills V0 to VX with values from memory starting at address I
    LD_VX_I = 0xF065
}
