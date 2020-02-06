using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using NUnit.Framework;

namespace IntegerConversionService.Test
{
	[TestFixture]
	public class TensTests
	{
		[TestCase("тридцати", 30, SubjectiveCase.Genitive)]
		[TestCase("тридцать", 30, SubjectiveCase.Nominative)]
		[TestCase("тридцатью", 30, SubjectiveCase.Instrumental)]
		[TestCase("", 0, SubjectiveCase.Nominative)]
		public void GetQuantitativeNumber_return_not_empty_string_for_10_20_30(string expectedResult, int arg,
			SubjectiveCase subjective)
		{
			var result = Tens.GetQuantitativeNumber(arg, subjective);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("сорок", 40, SubjectiveCase.Accusative)]
		[TestCase("сорока", 40, SubjectiveCase.Prepositional)]
		[TestCase("девяносто", 90, SubjectiveCase.Accusative)]
		[TestCase("девяноста", 90, SubjectiveCase.Prepositional)]
		public void GetQuantitativeNumber_return_not_empty_string_for_40_90(string expectedResult, int arg,
			SubjectiveCase subjective)
		{
			var result = Tens.GetQuantitativeNumber(arg, subjective);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("шестьдесят", 60, SubjectiveCase.Accusative)]
		[TestCase("шестидесяти", 60, SubjectiveCase.Prepositional)]
		[TestCase("шестьюдесятью", 60, SubjectiveCase.Instrumental)]
		public void GetQuantitativeNumber_return_not_empty_string_for_50_80(string expectedResult, int arg,
			SubjectiveCase subjective)
		{
			var result = Tens.GetQuantitativeNumber(arg, subjective);
			Assert.AreEqual(expectedResult, result);
		}
	}
}