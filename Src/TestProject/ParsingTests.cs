using Furesoft.PrattParser;
using AParser = EatFrog.Assembler.Core.AssemblyParser<TestProject.TestOpcodes>;

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