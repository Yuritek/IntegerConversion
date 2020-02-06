using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using NUnit.Framework;

namespace IntegerConversionService.Test
{
	[TestFixture]
	public class HundsTests
	{
		[TestCase("двести", 200, SubjectiveCase.Nominative)]
		[TestCase("двухсот", 200, SubjectiveCase.Genitive)]
		[TestCase("двумстам", 200, SubjectiveCase.Dative)]
		[TestCase("двести", 200, SubjectiveCase.Accusative)]
		[TestCase("двумястами", 200, SubjectiveCase.Instrumental)]
		[TestCase("двухстах", 200, SubjectiveCase.Prepositional)]
		public void GetQuantitativeNumber_return_not_empty_string_for_200_400(string expectedResult, int number,
			SubjectiveCase subjectiveCase)
		{
			var result = Hunds.GetQuantitativeNumber(number, subjectiveCase);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("шестьсот", 600, SubjectiveCase.Nominative)]
		[TestCase("шестисот", 600, SubjectiveCase.Genitive)]
		[TestCase("шестистам", 600, SubjectiveCase.Dative)]
		[TestCase("шестьсот", 600, SubjectiveCase.Accusative)]
		[TestCase("шестьюстами", 600, SubjectiveCase.Instrumental)]
		[TestCase("шестистах", 600, SubjectiveCase.Prepositional)]
		public void GetQuantitativeNumber_return_not_empty_string_for_500_900(string expectedResult, int number,
			SubjectiveCase subjectiveCase)
		{
			var result = Hunds.GetQuantitativeNumber(number, subjectiveCase);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("сто", 100, SubjectiveCase.Nominative)]
		[TestCase("ста", 100, SubjectiveCase.Prepositional)]
		public void GetQuantitativeNumber_return_not_empty_string_for_100(string expectedResult, int number,
			SubjectiveCase subjectiveCase)
		{
			var result = Hunds.GetQuantitativeNumber(number, subjectiveCase);
			Assert.AreEqual(expectedResult, result);
		}
	}
}