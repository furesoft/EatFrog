using EatFrog.Platforms.Chip8;

namespace TestProject;

public class AssemblyTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Read_Should_Pass()
    {
        var tree = new Chip8Assembly();
        var testRom = File.OpenRead("test_opcode.ch8");

        tree.Load(testRom);
    }
}