using System;
using System.Collections.Generic;

namespace CSharp.Dependencies
{
    public class Result<T>
    {
        public readonly bool IsOk;
        public readonly T Value;
        public readonly IEnumerable<Error> Errors;
        public readonly byte[] Timestamp;

        internal Result(IEnumerable<Error> errors)
        {
            IsOk = false;
            Value = default(T);
            Errors = errors;
            Timestamp = null;
        }

        internal Result()
        {
            IsOk = true;
            Value = default(T);
            Errors = new List<Error>();
            Timestamp = null;
        }

        internal Result(T value)
        {
            IsOk = true;
            Value = value;
            Errors = new List<Error>();
            Timestamp = null;
        }

        internal Result(T value, byte[] timestamp)
        {
            IsOk = true;
            Value = value;
            Errors = new List<Error>();
            Timestamp = timestamp;
        }

        internal Result(byte[] timestamp)
        {
            IsOk = true;
            Value = default(T);
            Errors = new List<Error>();
            Timestamp = timestamp;
        }
    }

    public static class Result
    {
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Ok<T>(T value, byte[] timestamp)
        {
            return new Result<T>(value, timestamp);
        }

        public static Result<T> Ok<T>(byte[] timestamp)
        {
            return new Result<T>(timestamp);
        }

        public static Result<T> Ok<T>()
        {
            return new Result<T>();
        }

        public static Result<T> Failed<T>(IEnumerable<Error> errors)
        {
            return new Result<T>(errors);
        }

        public static Result<T> Failed<T>(Error error)
        {
            return new Result<T>(new List<Error> {error});
        }

        public static T EnsureValid<T>(this Result<T> result)
        {
            if (!result.IsOk)
                throw new Exception(string.Join(Environment.NewLine, result.Errors));

            return result.Value;
        }
    }

    public class Error
    {
        private Error(string subject, ErrorType type, Exception exception, string message)
        {
            Subject = subject;
            Type = type;
            Message = message;
            Exception = exception;
        }

        private Error(string subject, ErrorType type, Exception exception, string message, string[] referenceData)
            : this(subject, type, exception, message)
        {
            ReferenceData = referenceData;
        }

        public Exception Exception { get; }
        public string Subject { get; }
        public string Message { get; }
        public string[] ReferenceData { get; }
        public ErrorType Type { get; }

        public static Error CreateFrom(string subject, ErrorType type, string message = null, string[] referenceData = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = DefaultMessage(type);
            }

            return new Error(subject, type, null, message, referenceData);
        }

        public static Error CreateFrom(Error error, string message)
        {
            return CreateFrom(error.Subject, error.Type, message);
        }

        public static Error CreateFrom(string subject, Exception exception)
        {
            return new Error(subject, ErrorType.InternalServerError, exception, exception.Message);
        }

        public static string DefaultMessage(ErrorType type)
        {
            return type.Id;
        }
    }

    public class ErrorType
    {
        public string Id { get; }

        private ErrorType(string id)
        {
            Id = id;
        }

        public static readonly ErrorType InternalServerError = new ErrorType("Internal server error");
        public static readonly ErrorType InvalidField = new ErrorType("Invalid field");
        public static readonly ErrorType ValueNotProvided = new ErrorType("Value not provided");
        public static readonly ErrorType NotFound = new ErrorType("Value not found");
        public static readonly ErrorType PreconditionFailedError = new ErrorType("Precondition failed error");
        public static readonly ErrorType NotValid = new ErrorType("Not valid");
    }
}