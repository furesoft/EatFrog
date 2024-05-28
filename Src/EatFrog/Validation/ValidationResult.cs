namespace EatFrog.Validation;

public class ValidationResult
{
    public List<string> Errors { get; } = new();

    public bool IsSuccess => Errors.Count == 0;
    
    public static implicit operator ValidationResult(bool value)
    {
        return new();
    }
    
    public static implicit operator ValidationResult(string error)
    {
        return new() { Errors = { error }};
    }

    public static bool operator true(ValidationResult result)
    {
        return result.IsSuccess;
    }
    
    public static bool operator false(ValidationResult result)
    {
        return !result.IsSuccess;
    }
    
    public static ValidationResult operator |(ValidationResult lhs, ValidationResult rhs)
    {
        var result = new ValidationResult();
        
        result.Errors.AddRange(lhs.Errors);
        result.Errors.AddRange(rhs.Errors);

        return result;
    }
    
    public static ValidationResult operator &(ValidationResult lhs, ValidationResult rhs)
    {
        var result = new ValidationResult();
        
        result.Errors.AddRange(lhs.Errors);
        result.Errors.AddRange(rhs.Errors);

        return result;
    }
}