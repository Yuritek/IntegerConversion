using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using NUnit.Framework;

namespace IntegerConversionService.Test
{
	[TestFixture]
	class Frac20Tests
	{
		[TestCase("одного", 1, SubjectiveCase.Genitive, Kind.Masculine)]
		[TestCase("одной", 1, SubjectiveCase.Genitive, Kind.FeminineGender)]
		[TestCase("трех", 3, SubjectiveCase.Genitive, Kind.Masculine)]
		[TestCase("трем", 3, SubjectiveCase.Dative, Kind.FeminineGender)]
		[TestCase("пяти", 5, SubjectiveCase.Genitive, Kind.None)]
		[TestCase("пятью", 5, SubjectiveCase.Instrumental, Kind.None)]
		[TestCase("пять", 5, SubjectiveCase.Nominative, Kind.None)]
		[TestCase("семнадцатью", 17, SubjectiveCase.Instrumental, Kind.None)]
		[TestCase("семнадцать", 17, SubjectiveCase.Nominative, Kind.None)]
		public void GetQuantitativeNumber_return_not_empty_string(string expectedResult, int arg, SubjectiveCase subjective,
			Kind kind)
		{
			var result = Frac20.GetQuantitativeNumber(arg, x => x % 100, subjective, kind);
			Assert.AreEqual(expectedResult, result);
		}
	}
}