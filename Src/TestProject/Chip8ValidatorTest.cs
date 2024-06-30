using System.Runtime.CompilerServices;
using EatFrog;
using EatFrog.Operands;
using EatFrog.Platforms.Chip8;
using Silverfly.Testing;

namespace TestProject;

public class Chip8ValidatorTest : SnapshotParserTestBase
{
    [ModuleInitializer]
    public static void Initialize()
    {
        Init();
    }

    private readonly Chip8InstructionValidator _validator = new();

    [Test]
    public Task NoOperand_Should_Pass()
    {
        var instruction = new Instruction<Chip8OpCode>(Chip8OpCode.RET);
        var validationResult = _validator.Validate(instruction);

        return Verify(validationResult, settings);
    }

    [Test]
    public Task OperandType_Should_Pass()
    {
        var instruction = new Instruction<Chip8OpCode>(Chip8OpCode.CALL, new Address(0xC00FFEE));
        var validationResult = _validator.Validate(instruction);

        return Verify(validationResult, settings);
    }

    [Test]
    public Task OperandNotType_Should_Pass()
    {
        var instruction = new Instruction<Chip8OpCode>(Chip8OpCode.CLS);
        var validationResult = _validator.Validate(instruction);

        return Verify(validationResult, settings);
    }
}