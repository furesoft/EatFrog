using EatFrog.Assembler.Core;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;
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
        var tree = Parser.Parse<AstNode, AParser>("call 42,5", "test.dsl");
        
        Assert.IsFalse(tree.Document.Messages.Any());
    }
}