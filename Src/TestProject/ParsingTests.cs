using System.Runtime.CompilerServices;
using EatFrog.Platforms.Chip8;
using Furesoft.PrattParser.Testing;

namespace TestProject;

public class ParsingTests : SnapshotParserTestBase
{
    readonly Chip8Maschine maschine = new();

    [ModuleInitializer]
    public static void Initialize() {
        Init();
    }

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

    [Test]
    public Task CallRegister_Should_Pass() {
        var tree = maschine.Parse("call ve");

        return Verify(tree, settings);
    }

    [Test]
    public Task Convert_CallRegisterToInstruction_Should_Pass() {
        var instruction = maschine.FromAssembler("call ve");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_ClsToInstruction_Should_Pass() {
        var instruction = maschine.FromAssembler("cls");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_CallWithTwoOperandsToInstruction_Should_Pass() {
        var instruction = maschine.FromAssembler("call 123, ve");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_CallWithTwoOperandsAndClsToInstruction_Should_Pass() {
        var instruction = maschine.FromAssembler("call 123, ve\ncls");

        return Verify(instruction, settings);
    }
}