using System;

namespace CSharp.Dependencies
{
    public class DateRange
    {
        public readonly DateTime Start;
        public readonly DateTime End;

        private DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public static Result<DateRange> FromValues(DateTime startDate, DateTime endDate, string subject)
        {
            var validator = new DateRangeValidator(startDate, endDate, subject);
            var dateRangeValidation = validator.Validate();

            if (!dateRangeValidation.IsOk)
            {
                return Result.Failed<DateRange>(dateRangeValidation.Errors);
            }

            var dateRange = new DateRange(startDate, endDate);

            return Result.Ok(dateRange);
        }
    }

    public class DateRangeValidator : Validator
    {
        private readonly DateTime _start;
        private readonly DateTime _end;
        private readonly string _subject;

        public override Result<ValidationResult> Validate()
        {
            if (_start > _end)
                return Result.Failed<ValidationResult>(Error.CreateFrom(_subject, ErrorType.InvalidField, "Invalid date range"));

            return Result.Ok<ValidationResult>();
        }

        public DateRangeValidator(DateTime start, DateTime end, string subject)
        {
            _start = start;
            _end = end;
            _subject = subject;
        }
    }
}