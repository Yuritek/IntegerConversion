using System;
using System.Collections.Generic;
using System.Text;
using IntegerConverstionService.Array;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;
using IntegerConverstionService.LogicArray;

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

		string Str(int val)
		{
			int num = val % 1000;
			if (0 == num) return "";
			if (num < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");

			StringBuilder r = new StringBuilder(Hunds.GetQuantitativeNumber(num, SubjectiveCaseNumber));

			if (num % 100 < 20)
			{
				r.Append(Frac20.GetQuantitativeNumber(num, x => x % 100, SubjectiveCaseNumber, NumberKind));
			}
			else
			{
				r.Append(Tens.GetQuantitativeNumber(num, SubjectiveCaseNumber));
				r.Append(Frac20.GetQuantitativeNumber(num, x => x % 10, SubjectiveCaseNumber, NumberKind));
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
				r.Append(Str(n));


			Queue<int> stack = new Queue<int>();
			while (n > 0)
			{
				n /= 1000;
				if (n > 0)
					stack.Enqueue(n);
			}

			Dictionary<int, Func<int, SubjectiveCase, string>> wq = new Dictionary<int, Func<int, SubjectiveCase, string>>
			{
				{(int) DegreesThousand.Thousand, (num, sub) => Str(num).GetQuantitativeThousandNumber(num, subjectiveCase)}
			};

			for (int i = 0; i < stack.Count && i<=1; i++)
			{
				var dequeue = stack.Dequeue();
				r.Insert(0, wq[i](dequeue, subjectiveCase));
			}

			//TODO: нет реализации для степеней больше тысячи

			if (minus) r.Insert(0, "минус ");

			r[0] = char.ToUpper(r[0]);

			return r.ToString();
		}
	}
}