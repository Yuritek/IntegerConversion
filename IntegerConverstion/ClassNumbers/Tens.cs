using System;
using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.ClassNumbers
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

		private static readonly Dictionary<SubjectiveCase, Func<string, string, string>> Dict_50_80 =
			new Dictionary<SubjectiveCase, Func<string, string, string>>
			{
				{SubjectiveCase.Nominative, (s, s2) => s.AddSymbol(s2.DeleteLastSymbol())},
				{SubjectiveCase.Genitive, (s, s2) => s.AddSymbol(s2)},
				{SubjectiveCase.Dative, (s, s2) => s.AddSymbol(s2)},
				{SubjectiveCase.Accusative, (s, s2) => s.AddSymbol(s2.DeleteLastSymbol())},
				{SubjectiveCase.Instrumental, (s, s2) => s.AddSymbol(s2)},
				{SubjectiveCase.Prepositional, (s, s2) => s.AddSymbol(s2)}
			};

		public static readonly Dictionary<SubjectiveCase, Func<string, string, string>> Dict_40_or_90 =
			new Dictionary<SubjectiveCase, Func<string, string, string>>
			{
				{SubjectiveCase.Nominative, (s, s2) => s.Trim()},
				{SubjectiveCase.Genitive, (s, s2) => s.ReplaceSymbol(s2)},
				{SubjectiveCase.Dative, (s, s2) => s.ReplaceSymbol(s2)},
				{SubjectiveCase.Accusative, (s, s2) => s.Trim()},
				{SubjectiveCase.Instrumental, (s, s2) => s.ReplaceSymbol(s2)},
				{SubjectiveCase.Prepositional, (s, s2) => s.ReplaceSymbol(s2)}
			};

		private static readonly Func<int, SubjectiveCase, string> GetQuantitativeFrac20 = (index, subjectiveCase) =>
		{
			return Frac20.GetQuantitativeNumber(index, x => x % 100, subjectiveCase);
		};

		static readonly Dictionary<int, Func<SubjectiveCase, int, string>> DictTens =
			new Dictionary<int, Func<SubjectiveCase, int, string>>
			{
				{0, (s, index) => ""},
				{1, (s, index) => Frac20.Frac5_19[s](NominativeArray[index])},
				{2, (s, index) => Frac20.Frac5_19[s](NominativeArray[index])},
				{3, (s, index) => Frac20.Frac5_19[s](NominativeArray[index])},
				{4, (s, index) => Dict_40_or_90[s](NominativeArray[index].AddSpace(), "а")},
				{5, (s, index) => Dict_50_80[s](GetQuantitativeFrac20(index, s), GetQuantitativeFrac20(10, s))},
				{6, (s, index) => Dict_50_80[s](GetQuantitativeFrac20(index, s), GetQuantitativeFrac20(10, s))},
				{7, (s, index) => Dict_50_80[s](GetQuantitativeFrac20(index, s), GetQuantitativeFrac20(10, s))},
				{8, (s, index) => Dict_50_80[s](GetQuantitativeFrac20(index, s), GetQuantitativeFrac20(10, s))},
				{9, (s, index) => Dict_40_or_90[s](NominativeArray[index], "а")}
			};

		public static string GetQuantitativeNumber(int number, SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			var index = GetSerialNumber(number);
			return DictTens[index](subjectiveCase, index);
		}

		private static int GetSerialNumber(int number)
		{
			return number % 100 / 10;
		}
	}
}