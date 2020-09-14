using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace NotesService.Domain.Exeptions
{
	public class NotValidExeption : Exception
	{
		private const string RequestCannotBeNullErrorMessage = "Request cannot be null.";

		private readonly List<ValidationError> _errors;

		public NotValidExeption(ValidationError error)
		{
			_errors = new List<ValidationError> { error };
		}

		public NotValidExeption(IEnumerable<ValidationError> errors)
		{
			_errors = errors.ToList();
		}

		public NotValidExeption(IEnumerable<ValidationFailure> errors)
		{
			_errors = errors
				.Select(x => new ValidationError(ValidationErrorType.Field, x.ErrorMessage))
				.ToList();
		}

		public IReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();

		public NotValidExeption AddError(ValidationError error)
		{
			_errors.Add(error);
			return this;
		}

		public NotValidExeption AddErrors(IEnumerable<ValidationError> errors)
		{
			_errors.AddRange(errors);
			return this;
		}

		public static void ThrowRequestCannotBeNull()
		{
			var error = new ValidationError(ValidationErrorType.Form, RequestCannotBeNullErrorMessage);
			throw new NotValidExeption(error);
		}

		public static void ThrowWithErrors(IEnumerable<ValidationFailure> errors)
		{
			throw new NotValidExeption(errors);
		}
	}

	public class ValidationError
	{
		public ValidationError(ValidationErrorType type, string message)
		{
			Type = type;
			Message = message;
		}

		public ValidationErrorType Type { get; }

		public string Message { get; }
	}

	public enum ValidationErrorType
	{
		Form,
		Field
	}
}
