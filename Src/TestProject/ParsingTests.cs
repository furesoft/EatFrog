using EatFrog.Platforms.Chip8;

namespace TestProject;

public class ParsingTests : SnapshotTestBase
{
    Chip8Maschine maschine = new();

    [Test]
    public Task Block_Multiple_Children_Should_Pass()
    {
        var tree = maschine.Parse("call 42,5\ncls", "test.dsl");

        return Verify(tree, settings);
    }

    [Test]
    public Task Block_Single_Children_Should_Pass()
    {
        var tree = maschine.Parse("call 42,5", "test.dsl");

        return Verify(tree, settings);
    }
}