using System.Linq;

namespace CSharp.Dependencies
{
    public class ValidationResult
    {

    }

    public interface IValidator
    {
        Result<ValidationResult> Validate();
        IValidator And(IValidator validator);
    }

    public abstract class Validator : IValidator
    {
        public abstract Result<ValidationResult> Validate();

        public IValidator And(IValidator validator)
        {
            return new AndValidator(this, validator);
        }
    }

    public class AndValidator : Validator
    {
        private IValidator _leftValidator;
        private IValidator _rightValidator;
        
        public override Result<ValidationResult> Validate()
        {
            return From(_leftValidator.Validate(), _rightValidator.Validate());
        }

        public AndValidator(IValidator leftValidator, IValidator rightValidator)
        {
            _leftValidator = leftValidator;
            _rightValidator = rightValidator;
        }
        
        public static Result<ValidationResult> From(Result<ValidationResult> leftValidationResult, Result<ValidationResult> rightValidationResult)
        {
            return
                leftValidationResult.IsOk && rightValidationResult.IsOk
                    ? Result.Ok(new ValidationResult())
                    : Result.Failed<ValidationResult>(leftValidationResult.Errors.Concat(rightValidationResult.Errors));
        }
    }
}