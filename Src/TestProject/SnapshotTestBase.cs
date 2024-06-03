using System.Runtime.CompilerServices;
using Argon;
using Furesoft.PrattParser.Testing;
using static VerifyTests.VerifierSettings;

namespace TestProject;

public abstract class SnapshotTestBase
{
    public static VerifySettings settings = new VerifySettings();

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

        settings.UseDirectory("TestResults");
    }
}
