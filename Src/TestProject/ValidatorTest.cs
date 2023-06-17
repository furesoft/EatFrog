using EatFrog;
using EatFrog.Operands;
using EatFrog.Validation;
using EatFrog.Validation.Builder.BuilderExtensions;

namespace TestProject;

class X86Validator : InstructionValidator<TestOpcodes>
{
    public X86Validator()
    {
        For(TestOpcodes.Ret).NoOperands();
        For(TestOpcodes.Call).Operand(0, _ =>
        {
            _.OfType<Address>();
        });
    }
}

public class ValidatorTest
{
    private readonly X86Validator _validator = new X86Validator();
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void NoOperand_Should_Pass()
    {
        var instruction = new Instruction<TestOpcodes>(TestOpcodes.Ret);
        var validationResult = _validator.Validate(instruction);
        
        Assert.IsTrue(validationResult);
    }
    
    [Test]
    public void OperandType_Should_Pass()
    {
        var instruction = new Instruction<TestOpcodes>(TestOpcodes.Call, new Address(0xC00FFEE));
        var validationResult = _validator.Validate(instruction);
        
        Assert.IsTrue(validationResult);
    }
}