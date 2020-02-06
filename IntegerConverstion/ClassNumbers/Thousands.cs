using System;
using System.Collections.Generic;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.ClassNumbers
{
	public static class Thousands
	{
		private static readonly Dictionary<SubjectiveCase, Func<string, BitDepth, string>> DeclinationThousand =
			new Dictionary<SubjectiveCase, Func<string, BitDepth, string>>
			{
				{
					SubjectiveCase.Nominative,
					(s, depth) => s.AddSymbol(depth == BitDepth.Unit ?"а":depth == BitDepth.LessFive ?"и":"")
				},
				{SubjectiveCase.Genitive, (s, depth) => s.AddSymbol(depth == BitDepth.Unit?"и":"")},
				{SubjectiveCase.Dative, (s, depth) =>  s.AddSymbol(depth == BitDepth.Unit ?"е":"ам") },
				{
					SubjectiveCase.Accusative,
					(s, depth) =>s.AddSymbol( depth == BitDepth.Unit?"у":depth == BitDepth.LessFive?"и":"") 
				},
				{SubjectiveCase.Instrumental, (s, depth) =>  s.AddSymbol(depth == BitDepth.Unit ?"ей":"ами")},
				{SubjectiveCase.Prepositional, (s, depth) =>  s.AddSymbol(depth == BitDepth.Unit ?"е":"ах")},
			};

		 public static string GetQuantitativeThousandNumber(this string val, int number,
			SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			int serialNumber = GetSerialNumber(number);

			if (string.IsNullOrEmpty(val))
				return "";
			return string.Concat(val,
				DeclinationThousand[subjectiveCase]("тысяч",GetBitDepth(serialNumber)));
		}

		private static int GetSerialNumber(int number)
		{
			return number % 100 > 20 ? number % 10 : number % 20;
		}

		private static BitDepth GetBitDepth(int serialNumber)
		{
			return serialNumber == 1 ? BitDepth.Unit :
				serialNumber >= 2 && serialNumber < 5 ? BitDepth.LessFive : BitDepth.MoreFive;
		}
	}
}