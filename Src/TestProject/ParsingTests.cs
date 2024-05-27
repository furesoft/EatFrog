using EatFrog.Platforms.Chip8;
using Furesoft.PrattParser;

namespace TestProject;

public class ParsingTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Opcode_Should_Pass()
    {
        var tree = Parser.Parse<Chip8AssemblyParser>("call 42,5\nmov 2,3", "test.dsl");
        
        Assert.IsFalse(tree.Document.Messages.Any());
    }
}