using Furesoft.PrattParser.Nodes;

namespace EatFrog.Assembler.Core.Nodes;

internal class LabelNode : AstNode
{
    public LabelNode(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}