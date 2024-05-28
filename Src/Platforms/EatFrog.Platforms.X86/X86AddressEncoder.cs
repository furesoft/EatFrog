namespace EatFrog.Platforms.X86;

using System;

public class X86AddressEncoder : IAddressEncoder
{
    public byte[] Encode(ulong address)
    {
        byte[] encodedAddress = new byte[8]; // Assuming x86 addresses are 8 bytes

        // Convert the ulong address into a byte array
        for (int i = 0; i < 8; i++)
        {
            encodedAddress[i] = (byte)(address & 0xFF); // Extract the least significant byte
            address >>= 8; // Shift right to get the next byte
        }

        return encodedAddress;
    }
}
