using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Nodes;

public class MacroNode(Symbol mnemnonic, List<AstNode> arguments)
{
    public Symbol Mnemnonic { get; } = mnemnonic;
    public List<AstNode> Arguments { get; } = arguments;
}