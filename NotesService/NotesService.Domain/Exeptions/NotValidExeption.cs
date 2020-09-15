using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace NotesService.Domain.Exeptions
{
	public class NotValidExeption : Exception
	{
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

		public static void ThrowCannotBeNull(string entityName)
		{
			var errorMessage = $"{entityName} cannot be null.";
			var error = new ValidationError(ValidationErrorType.Form, errorMessage);
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
