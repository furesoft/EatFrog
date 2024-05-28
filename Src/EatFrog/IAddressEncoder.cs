namespace EatFrog;

public interface IAddressEncoder
{
    byte[] Encode(ulong address);
}