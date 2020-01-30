using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.LogicArray
{
	/// <summary>
	/// Наименования сотен
	/// </summary>
	public static class Hunds
	{
		private static readonly string[] NominativeArray =
		{
			"", "сто ", "двести ", "триста ", "четыреста ",
			"пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
		};

		private static readonly string[] BaseArray =
		{
			"", "ста ", "дву", "тре", "четыре", "пят", "шест", "сем", "восем", "девят"
		};

		private static readonly Dictionary<SubjectiveCase, string> TwoToFive = new Dictionary<SubjectiveCase, string>
		{
			{SubjectiveCase.Genitive, "хсот"},
			{SubjectiveCase.Dative, "мстам"},
			{SubjectiveCase.Instrumental, "мястами"},
			{SubjectiveCase.Prepositional, "хстах"}
		};

		private static readonly Dictionary<SubjectiveCase, string> FiveToNine = new Dictionary<SubjectiveCase, string>
		{
			{SubjectiveCase.Genitive, "исот"},
			{SubjectiveCase.Dative, "истам"},
			{SubjectiveCase.Instrumental, "ьюстами"},
			{SubjectiveCase.Prepositional, "истах"}
		};

		public static string GetQuantitativeNumber(int number, SubjectiveCase subjectiveCase)
		{
			var index = number / 100;
			if (index >= 2 && index < 5)
			{
				if (TwoToFive.TryGetValue(subjectiveCase, out var result))
				{
					return BaseArray[index].AddSymbolWidthSpace(result);
				}
			}

			if (index >= 5 && index <= 9)
			{
				if (FiveToNine.TryGetValue(subjectiveCase, out var result))
				{
					return BaseArray[index].AddSymbolWidthSpace(result);
			 }
			}

			if (index == 1 && subjectiveCase != SubjectiveCase.Nominative && subjectiveCase != SubjectiveCase.Accusative)
			{
				return BaseArray[index];
			}

			return NominativeArray[index];
		}
	}
}