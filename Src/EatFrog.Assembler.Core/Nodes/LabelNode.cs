using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

internal class LabelNode(string name) : AstNode
{
    public string Name { get; set; } = name;
}