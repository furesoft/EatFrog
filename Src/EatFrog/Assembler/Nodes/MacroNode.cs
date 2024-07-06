using System.Collections.Immutable;
using Silverfly;
using Silverfly.Nodes;

namespace EatFrog.Assembler.Nodes;

public record MacroNode(Symbol Mnemnonic, ImmutableList<AstNode> Arguments) : AstNode
{
}