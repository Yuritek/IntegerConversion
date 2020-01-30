using IntegerConverstionService.Enums;

namespace IntegerConverstionService.Model
{
	public class QuantitativeNumber
	{
		public Kind Kind { get; set; }

		public SubjectiveCase SubjCase { get; set; }

		public string StrValue { get; set; }

		public int Index { get; set; }
	}
}
