using gamezone_api.Models;

namespace gamezone_api.Networking
{
    public class EditionResponse
	{
		public int Id { get; set; }

		public string Type { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var editionResponse = obj as EditionResponse;
            return
                this.Id == editionResponse.Id &&
                this.Type == editionResponse.Type;
        }
    }
}

