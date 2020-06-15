using System;

namespace CSharp.Dependencies
{
    public class DateTimeValidator : Validator
    {
        private readonly string _date;
        private readonly string _subject;
        
        public DateTimeValidator(string date, string subject)
        {
            _date = date;
            _subject = subject;
        }

        public override Result<ValidationResult> Validate()
        {
            if (string.IsNullOrEmpty(_date))
                return Result.Failed<ValidationResult>(Error.CreateFrom(_subject, ErrorType.ValueNotProvided));
            
            return DateTime.TryParse(_date, out _)? 
                Result.Ok<ValidationResult>() : 
                Result.Failed<ValidationResult>(Error.CreateFrom(_subject, ErrorType.InvalidField));
        }
    }
}