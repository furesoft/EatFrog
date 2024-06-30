using System.Collections.Immutable;
using Silverfly;
using Silverfly.Nodes;

namespace EatFrog.Assembler.Nodes;

public record MacroNode(string Mnemnonic, ImmutableList<AstNode> Arguments) : AstNode
{
}