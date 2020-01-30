using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.LogicArray
{
	public static class Thousand
	{
		private static readonly Dictionary<BitDepth, Dictionary<SubjectiveCase, string>> DeclinationThousand =
			new Dictionary<BitDepth, Dictionary<SubjectiveCase, string>>
			{
				{
					BitDepth.Unit, new Dictionary<SubjectiveCase, string>
					{
						{SubjectiveCase.Nominative, "тысяча"},
						{SubjectiveCase.Genitive, "тысячи"},
						{SubjectiveCase.Dative, "тысяче"},
						{SubjectiveCase.Accusative, "тысячу"},
						{SubjectiveCase.Instrumental, "тысячей"},
						{SubjectiveCase.Prepositional, "тысяче"}
						
					}

				},
				{
					BitDepth.LessFive, new Dictionary<SubjectiveCase, string>
					{
						{SubjectiveCase.Nominative, "тысячи"},
						{SubjectiveCase.Genitive, "тысяч"},
						{SubjectiveCase.Dative, "тысячам"},
						{SubjectiveCase.Accusative, "тысячи"},
						{SubjectiveCase.Instrumental, "тысячами"},
						{SubjectiveCase.Prepositional, "тысячах"},
					}

				},
				{
					BitDepth.MoreFive, new Dictionary<SubjectiveCase, string>
					{
						{SubjectiveCase.Nominative, "тысяч"},
						{SubjectiveCase.Genitive, "тысяч"},
						{SubjectiveCase.Dative, "тысячам"},
						{SubjectiveCase.Accusative, "тысяч"},
						{SubjectiveCase.Instrumental, "тысячами"},
						{SubjectiveCase.Prepositional, "тысячах"}
					}

				},
			};

		public static string GetQuantitativeThousandNumber(this string val, int number, SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			int t = number % 100 > 20 ? number % 10 : number % 20;

		  if (string.IsNullOrEmpty(val))
				return "";
			if (t == 1)
				return string.Concat(val,DeclinationThousand[BitDepth.Unit][subjectiveCase]).AddSpace();
			if (t >= 2 && t < 5)
				return string.Concat(val, DeclinationThousand[BitDepth.LessFive][subjectiveCase]).AddSpace();
		  return string.Concat(val, DeclinationThousand[BitDepth.MoreFive][subjectiveCase]).AddSpace();
		}
	}
}