using Furesoft.PrattParser;
using Furesoft.PrattParser.Nodes;

namespace EatFrog;

internal class InstructionConversionVisitor<TOpCode> : IVisitor<IEnumerable<Instruction<TOpCode>>>
    where TOpCode : struct
{
    public IEnumerable<Instruction<TOpCode>> Visit(AstNode node)
    {
        throw new NotImplementedException();
    }
}