using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class EditionsMapper : IEditionsMapper
	{
		public Edition Map(EditionRequest editionRequest)
		{
			return new Edition
			{
				Type = editionRequest.Type
			};
		}

		public EditionResponse Map(Edition edition)
		{
			return new EditionResponse
			{
				Id = edition.Id,
				Type = edition.Type
			};
		}
	}

	public interface IEditionsMapper
	{
		Edition Map(EditionRequest editionRequest);

		EditionResponse Map(Edition edition);
    }
}

