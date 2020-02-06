using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using NUnit.Framework;

namespace IntegerConversionService.Test
{
	[TestFixture]
	public class ThousandTests
	{
		[TestCase("четыре тысячи", 4, SubjectiveCase.Nominative, "четыре ")]
		[TestCase("четыре тысячами", 4, SubjectiveCase.Instrumental, "четыре ")]
		[TestCase("", 4, SubjectiveCase.Instrumental, "")]
		public void GetQuantitativeNumber_return_not_empty_string_for_1000(string expectedResult, int arg,
			SubjectiveCase subjective, string sourceString)
		{
			var result = sourceString.GetQuantitativeThousandNumber(arg, subjective);
			Assert.AreEqual(expectedResult, result);
		}
	}
}