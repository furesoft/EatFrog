namespace EatFrog.Platforms.Chip8;

public class Chip8AddressEncoder : IAddressEncoder
{
    public byte[] Encode(ulong address)
    {
        // Ensure the address is within the valid range for CHIP-8 (0x000 to 0xFFF)
        if (address > 0xFFF)
        {
            throw new ArgumentOutOfRangeException(nameof(address), "Address must be within the range 0x000 to 0xFFF for CHIP-8.");
        }

        // The address is 12 bits, so we need to split it into two bytes
        byte highByte = (byte)((address >> 8) & 0x0F); // Get the higher 4 bits of the address
        byte lowByte = (byte)(address & 0xFF); // Get the lower 8 bits of the address

        // Combine the high and low parts into a byte array
        return [highByte, lowByte];
    }
}