using System;
using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.ClassNumbers
{
	/// <summary>
	/// Наименования сотен
	/// </summary>
	public static class Hunds
	{
		private static readonly string[] NominativeArray =
		{
			"", "сто", "двести", "триста", "четыреста",
			"пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
		};


		private static readonly Dictionary<SubjectiveCase, string> OneHundred =
			new Dictionary<SubjectiveCase, string>
			{
				{SubjectiveCase.Nominative, "сот"},
				{SubjectiveCase.Genitive, "сот"},
				{SubjectiveCase.Dative, "стам"},
				{SubjectiveCase.Accusative, "сот"},
				{SubjectiveCase.Instrumental, "стами"},
				{SubjectiveCase.Prepositional, "стах"}
			};

		private static readonly Func<int, SubjectiveCase, string> CalculationHunds = (x, y) =>
		{
			return Frac20.GetQuantitativeNumber(x, z => z % 100, y).AddSymbol(OneHundred[y]);
		};

		private static bool GetComparisonDozens(int number)
		{
			return number >= 2 && number < 5;
		}

		private static readonly Dictionary<SubjectiveCase, Func<int, SubjectiveCase, string>> TwoToNine =
			new Dictionary<SubjectiveCase, Func<int, SubjectiveCase, string>>
			{
				{SubjectiveCase.Nominative, (s, s2) => GetComparisonDozens(s) ? NominativeArray[s] : CalculationHunds(s, s2)},
				{SubjectiveCase.Genitive, (s, s2) => CalculationHunds(s, s2)},
				{SubjectiveCase.Dative, (s, s2) => CalculationHunds(s, s2)},
				{SubjectiveCase.Accusative, (s, s2) => GetComparisonDozens(s) ? NominativeArray[s] : CalculationHunds(s, s2)},
				{SubjectiveCase.Instrumental, (s, s2) => CalculationHunds(s, s2)},
				{SubjectiveCase.Prepositional, (s, s2) => CalculationHunds(s, s2)}
			};

		private static Dictionary<int, Func<SubjectiveCase, int, string>> DictHunds =
			new Dictionary<int, Func<SubjectiveCase, int, string>>
			{
				{0, (s, index) => ""},
				{1, (s, index) => Tens.Dict_40_or_90[s](NominativeArray[index], "а")},
				{2, (s, index) => TwoToNine[s](index, s)},
				{3, (s, index) => TwoToNine[s](index, s)},
				{4, (s, index) => TwoToNine[s](index, s)},
				{5, (s, index) => TwoToNine[s](index, s)},
				{6, (s, index) => TwoToNine[s](index, s)},
				{7, (s, index) => TwoToNine[s](index, s)},
				{8, (s, index) => TwoToNine[s](index, s)},
				{9, (s, index) => TwoToNine[s](index, s)}
			};

		public static string GetQuantitativeNumber(int number, SubjectiveCase subjectiveCase)
		{
			var index = GetSerialNumber(number);
			return DictHunds[index](subjectiveCase, index);
		}

		private static int GetSerialNumber(int number)
		{
			return number / 100;
		}
	}
}