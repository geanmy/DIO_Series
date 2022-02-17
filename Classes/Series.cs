namespace DIO.Series {
	public class Series : BaseEntity {
		private string title { get; set; }
		private string description { get; set; }
		private ushort year { get; set; }
		private Genders gender { get; set; }
		private bool deleted { get; set; }

		public Series(int id, string Title, string Description, ushort Year, Genders Gender) {
			this.Id = id;
			this.title = Title;
			this.description = Description;
			this.year = Year;
			this.gender = Gender;
			this.deleted = false;
		}

		public override string ToString() {
			string newLine = System.Environment.NewLine;

			return $"Gender: {gender}{newLine}Title: {title}{newLine}Description: {description}{newLine}Year: {year}{newLine}";
		}

		public string GetTitle() {
			return title;
		}

		public bool IsActive() { 
			return !deleted;
		}

		public void Delete() => this.deleted = true;
	}
}