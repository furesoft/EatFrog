using System.Runtime.CompilerServices;
using EatFrog;
using EatFrog.Assembler;
using EatFrog.Operands;
using EatFrog.Platforms.Chip8;
using Silverfly.Testing;

namespace TestProject;

public class Chip8ValidatorTest : SnapshotParserTestBase<AssemblyParser<Chip8Opcode, Chip8Register>>
{
    [ModuleInitializer]
    public static void Initialize() {
        Init(new TestOptions(UseStatementsAtToplevel: true, Filename: "test.dsl"));
    }

    private readonly Chip8InstructionValidator _validator = new();

    [Test]
    public Task NoOperand_Should_Pass()
    {
        var instruction = new Instruction<Chip8Opcode>(Chip8Opcode.RET);
        var validationResult = _validator.Validate(instruction);

        return Verify(validationResult, Settings);
    }
    
    [Test]
    public Task OperandType_Should_Pass()
    {
        var instruction = new Instruction<Chip8Opcode>(Chip8Opcode.CALL, new Address(0xC00FFEE));
        var validationResult = _validator.Validate(instruction);

        return Verify(validationResult, Settings);
    }
    
    [Test]
    public Task OperandNotType_Should_Pass()
    {
        var instruction = new Instruction<Chip8Opcode>(Chip8Opcode.CLS);
        var validationResult = _validator.Validate(instruction);
        
        return Verify(validationResult, Settings);
    }
}