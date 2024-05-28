using EatFrog.Assembler.Core.Nodes;
using EatFrog.Platforms.Chip8;
using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace TestProject;

public class ParsingTests
{
    Chip8Maschine maschine = new();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Opcode_Should_Pass()
    {
        var tree = maschine.Parse("call 42,5\ncls", "test.dsl");
        
        Assert.IsFalse(tree.Document.Messages.Count != 0);

        if(tree.Tree is BlockNode block) {
            if (block.Children[0] is InstructionNode<Chip8Opcode> callNode)
            {
                Assert.IsTrue(callNode.Operands.Count == 2);

                Assert.IsTrue(callNode.Opcode == Chip8Opcode.CALL);

                Assert.IsTrue(callNode.Operands[0] is LiteralNode<ulong> v && v.Value == 42);
                Assert.IsTrue(callNode.Operands[1] is LiteralNode<ulong> v2 && v2.Value == 5);
            }
            else
            {
                Assert.Fail();
            }

            if (block.Children[1] is InstructionNode<Chip8Opcode> clsNode)
            {
                Assert.IsTrue(clsNode.Operands.Count == 0);

                Assert.IsTrue(clsNode.Opcode == Chip8Opcode.CLS);
            }
            else
            {
                Assert.Fail();
            }
        }

        Assert.Fail("The root has to be of type BlockNode");
    }
}