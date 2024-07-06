using System.Runtime.CompilerServices;
using EatFrog.Assembler;
using EatFrog.Platforms.Chip8;
using Silverfly.Testing;

namespace TestProject;

public class ParsingTests : SnapshotParserTestBase<AssemblyParser<Chip8Opcode, Chip8Register>>
{
    readonly Chip8Maschine maschine = new();

    [ModuleInitializer]
    public static void Initialize() {
        Init(new TestOptions(UseStatementsAtToplevel: true, Filename: "test.dsl"));
    }

    [Test]
    public Task Block_Multiple_Children_Should_Pass()
    {
        return Test("call 42,5\ncls");
    }

    [Test]
    public Task Block_Single_Children_Should_Pass()
    {
        return Test("call 42,5");
    }

    [Test]
    public Task CallRegister_Should_Pass() {
        return Test("call ve");
    }
}