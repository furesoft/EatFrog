using EatFrog;
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
        var assembly = new Chip8Assembly();
        var testRom = File.OpenRead("test.ch8");

        assembly.Load(testRom);
    }

    [Test]
    public void Write_Should_Pass()
    {
        var assembly = new Chip8Assembly();
        var testRom = File.OpenWrite("test.ch8");

        assembly.Instructions.Add(new Instruction<Chip8Opcode>(Chip8Opcode.RET));
        assembly.Instructions.Add(new Instruction<Chip8Opcode>(Chip8Opcode.CLS));

        assembly.Save(testRom);
    }
}