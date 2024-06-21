using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Nodes;

public class MacroNode(string mnemnonic, List<AstNode> arguments) : AstNode
{
    public Symbol Mnemnonic { get; } = mnemnonic;
    public List<AstNode> Arguments { get; } = arguments;
}