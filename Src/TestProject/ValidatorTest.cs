using EatFrog;
using EatFrog.Validation;

namespace TestProject;

class X86Validator : InstructionValidator<TestOpcodes>
{
    public X86Validator()
    {
        For(TestOpcodes.Ret).NoOperands();
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
}