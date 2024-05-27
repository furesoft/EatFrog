using EatFrog;
using EatFrog.Operands;
using EatFrog.Platforms.X86;

namespace TestProject;

public class ValidatorTest
{
    private X86InstructionValidator _validator;

    
    [SetUp]
    public void Setup()
    {
        _validator = new();
    }

    [Test]
    public void NoOperand_Should_Pass()
    {
        var instruction = new Instruction<X86Opcode>(X86Opcode.RET);
        var validationResult = _validator.Validate(instruction);
        
        Assert.IsTrue(validationResult.IsSuccess);
    }
    
    [Test]
    public void OperandType_Should_Pass()
    {
        var instruction = new Instruction<X86Opcode>(X86Opcode.CALL, new Address(0xC00FFEE));
        var validationResult = _validator.Validate(instruction);
        
        Assert.IsTrue(validationResult.IsSuccess);
    }
    
    [Test]
    public void OperandNotType_Should_Pass()
    {
        var instruction = new Instruction<X86Opcode>(X86Opcode.CALL, new Value(0xC00FFEE));
        var validationResult = _validator.Validate(instruction);
        
        Assert.IsTrue(validationResult.IsSuccess);
    }
}