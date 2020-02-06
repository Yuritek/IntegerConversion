using System;
using System.Text;
using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;
using IntegerConverstionService.Service;

namespace IntegerConverstionService
{
	public class RusNumber
	{
		private Kind _numberKind;
		private Kind NumberKind => _numberKind == Kind.None ? Kind.Masculine : _numberKind;
		private SubjectiveCase SubjectiveCaseNumber { get; set; }

		public RusNumber(Kind kind = Kind.None, SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			_numberKind = kind;
			SubjectiveCaseNumber = subjectiveCase;
		}

		string ConvertNumberToWords(int val)
		{
			int num = val % 1000;
			if (0 == num) return "";
			if (num < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");


			var hunds = Hunds.GetQuantitativeNumber(num, SubjectiveCaseNumber);
			if (!string.IsNullOrEmpty(hunds))
				hunds=hunds.AddSpace();
			StringBuilder r = new StringBuilder(hunds);

			if (num % 100 < 20)
			{
				r.Append(Frac20.GetQuantitativeNumber(num, x => x % 100, SubjectiveCaseNumber, NumberKind).AddSpace());
			}
			else
			{
				r.Append(Tens.GetQuantitativeNumber(num, SubjectiveCaseNumber).AddSpace());
				r.Append(Frac20.GetQuantitativeNumber(num, x => x % 10, SubjectiveCaseNumber, NumberKind).AddSpace());
			}

			return r.ToString();
		}

		public string SumProp(int val, Kind kind = Kind.None, SubjectiveCase subjectiveCase = SubjectiveCase.Nominative)
		{
			_numberKind = kind;
			SubjectiveCaseNumber = subjectiveCase;

			bool minus = false;
			if (val < 0)
			{
				val = -val;
				minus = true;
			}

			int n = val;

			StringBuilder r = new StringBuilder();

			if (0 == n) r.Append("0".AddSpace());
			if (n % 1000 != 0)
				r.Append(ConvertNumberToWords(n));

			var formation=new FormationThousands(ConvertNumberToWords, subjectiveCase);

			formation.GetConvertSamplesInWords(ref r, n);

		  //TODO: нет реализации для степеней больше тысячи

		  if (minus) r.Insert(0, "минус ");

			r[0] = char.ToUpper(r[0]);

			return r.ToString();
		}
	}
}