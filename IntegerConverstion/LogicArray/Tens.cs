using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.Array
{
	/// <summary>
	/// Использование десятков
	/// </summary>
	public static class Tens
	{
		private static readonly string[] NominativeArray =
		{
			"", "десять", "двадцать", "тридцать", "сорок", "пятьдесят",
			"шестьдесят", "семьдесят", "восемьдесят", "девяносто"
		};

		private static readonly string[] BaseArray =
		{
			"", "десяти", "двадцати", "тридцати", "сорока", "пят", "шест", "сем", "восем", "девяноста"
		};

		private static readonly Dictionary<SubjectiveCase, string> BaseSuffix = new Dictionary<SubjectiveCase, string>
		{
			{SubjectiveCase.Genitive, "идесяти"},
			{SubjectiveCase.Dative, "идесяти"},
			{SubjectiveCase.Instrumental, "ьюдесятью"},
			{SubjectiveCase.Prepositional, "идесяти"}
		};

		public static string GetQuantitativeNumber(int number, SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			var index = number % 100 / 10;
			string defaultKey = NominativeArray[index];
			if (index >= 1 && index <= 3)
			{
				if (subjectiveCase == SubjectiveCase.Genitive || subjectiveCase == SubjectiveCase.Dative ||
				    subjectiveCase == SubjectiveCase.Prepositional)
				{
					return BaseArray[index].AddSpace();
				}

				if (subjectiveCase == SubjectiveCase.Instrumental)
					return defaultKey.AddSymbolWidthSpace("ю");
			}

			if (index >= 5 && index <= 8)
			{
				if (BaseSuffix.TryGetValue(subjectiveCase, out var result))
				{
					return BaseArray[index].AddSymbolWidthSpace(result);
				}
			}

			if (index == 4 || index == 9)
			{
				if (subjectiveCase == SubjectiveCase.Genitive || subjectiveCase == SubjectiveCase.Dative ||
				    subjectiveCase == SubjectiveCase.Instrumental || subjectiveCase == SubjectiveCase.Prepositional)
				{
					return BaseArray[index].AddSpace();
				}
			}

			return defaultKey.AddSpace();
		}
	}
}