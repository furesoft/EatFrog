using Furesoft.PrattParser;
using AParser = EatFrog.Assembler.Core.AssemblyParser<EatFrog.Platforms.X86.X86Opcode>;

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
        var tree = Parser.Parse<AParser>("call 42,5\nmov 2,3", "test.dsl");
        
        Assert.IsFalse(tree.Document.Messages.Any());
    }
}