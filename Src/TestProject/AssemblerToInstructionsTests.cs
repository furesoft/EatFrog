using System.Runtime.CompilerServices;
using EatFrog.Platforms.Chip8;
using Silverfly.Testing;

namespace TestProject;

public class AssemblerToInstructionsTests : SnapshotParserTestBase
{
    readonly Chip8Maschine maschine = new();

    [ModuleInitializer]
    public static void Initialize()
    {
        Init();
    }

    [Test]
    public Task Convert_CallRegisterToInstruction_Should_Pass()
    {
        var instruction = maschine.FromAssembler("call ve");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_ClsToInstruction_Should_Pass()
    {
        var instruction = maschine.FromAssembler("cls");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_CallWithTwoOperandsToInstruction_Should_Pass()
    {
        var instruction = maschine.FromAssembler("call 123, ve");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_CallWithTwoOperandsAndClsToInstruction_Should_Pass()
    {
        var instruction = maschine.FromAssembler("call 123, ve\ncls");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Convert_CallWithLabelToInstruction_Should_Pass()
    {
        var instruction = maschine.FromAssembler("call $myLabel");

        return Verify(instruction, settings);
    }

    [Test]
    public Task Macro_Add_Should_Pass()
    {
        var instruction = maschine.FromAssembler("add I, V0");

        return Verify(instruction, settings);
    }
}
