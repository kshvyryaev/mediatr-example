using System;

namespace NotesService.Domain.Exeptions
{
	public class NotFoundExeption : Exception
	{
		public NotFoundExeption(string message) : base(message)
		{
		}

		public static void ThrowWithMessage(string message)
		{
			throw new NotFoundExeption(message);
		}

		public static void ThrowWithId<TId>(string entityName, TId id)
		{
			var message = $"{entityName} was not found with id = {id}";
			throw new NotFoundExeption(message);
		}
	}
}
