using IntegerConverstionService;
using IntegerConverstionService.Enums;
using NUnit.Framework;


namespace IntegerConversionService.Test
{
	[TestFixture]
	public class IntegerConverstionTests
	{
		private RusNumber _rusNumber;

		[SetUp]
		public void Initialize()
		{
			_rusNumber = new RusNumber();
		}

		[TestCase("Тридцать один ", 31, Kind.None, SubjectiveCase.Nominative)]
		[TestCase("Тридцать одна ", 31, Kind.FeminineGender, SubjectiveCase.Nominative)]
		[TestCase("Тридцати одного ", 31, Kind.Masculine, SubjectiveCase.Genitive)]
		[TestCase("Тридцати одной ", 31, Kind.FeminineGender, SubjectiveCase.Genitive)]
		[TestCase("Двадцатью двумя ", 22, Kind.NeuterGender, SubjectiveCase.Instrumental)]
		[TestCase("Одним ", 1, Kind.NeuterGender, SubjectiveCase.Instrumental)]
		[TestCase("Десятью ", 10, Kind.NeuterGender, SubjectiveCase.Instrumental)]
		[TestCase("0 ", 0, Kind.NeuterGender, SubjectiveCase.Instrumental)]
		public void SumProp_should_return_not_empty_string_for_less_thousand(string expectedResult, int arg, Kind kind,
			SubjectiveCase subjectiveCase)
		{
			var result = _rusNumber.SumProp(arg, kind, subjectiveCase);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("Сто пятьдесят четыре тысячи триста двадцать три ", 154323, Kind.Masculine, SubjectiveCase.Nominative)]
		[TestCase("Ста пятьюдесятью четырьмя тысячами тремястами двадцатью тремя ", 154323, Kind.Masculine,
			SubjectiveCase.Instrumental)]
		public void SumProp_should_return_not_empty_string_within_thousand(string expectedResult, int arg, Kind kind,
			SubjectiveCase subjectiveCase)
		{
			var result = _rusNumber.SumProp(arg, kind, subjectiveCase);
			Assert.AreEqual(expectedResult, result);
		}
	}
}