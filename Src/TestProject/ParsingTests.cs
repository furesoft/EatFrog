using System.Runtime.CompilerServices;
using Argon;
using EatFrog.Assembler.Core.Nodes;
using EatFrog.Platforms.Chip8;
using Furesoft.PrattParser.Testing;
using static VerifyTests.VerifierSettings;

namespace TestProject;

public class ParsingTests
{
    Chip8Maschine maschine = new();

    [ModuleInitializer]
    public static void Init()
    {
        AddExtraSettings(_ =>
        {
            _.Converters.Add(new SymbolConverter());
            _.Converters.Add(new DocumentConverter());
            _.Converters.Add(new RangeConverter());
            _.TypeNameHandling = TypeNameHandling.All;
        });
    }

    [Test]
    public Task Block_Multiple_Children_Should_Pass()
    {
        var tree = maschine.Parse("call 42,5\ncls", "test.dsl");

        return Verify(tree);
    }
}