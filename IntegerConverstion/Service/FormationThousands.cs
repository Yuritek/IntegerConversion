using System;
using System.Collections.Generic;
using System.Text;
using IntegerConverstionService.ClassNumbers;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;

namespace IntegerConverstionService.Service
{
	public class FormationThousands
	{
		private readonly Dictionary<int, Func<int, string>> _thousandsFunc;

		public FormationThousands(Func<int, string> convertNumberToWords, SubjectiveCase subjectiveCase)
		{
			_thousandsFunc = new Dictionary<int, Func<int, string>>
			{
				{
					(int) DegreesThousand.Thousand,
					num => convertNumberToWords(num).GetQuantitativeThousandNumber(num, subjectiveCase)
				}
			};
		}

		public void GetConvertSamplesInWords(ref StringBuilder content, int number)
		{
			Queue<int> stack = GetStackNumber(number);

			for (int i = 0; i < stack.Count && i <= 1; i++)
			{
				var dequeue = stack.Dequeue();
				content.Insert(0, _thousandsFunc[i](dequeue).AddSpace());
			}
		}

		private Queue<int> GetStackNumber(int number)
		{
			var stack = new Queue<int>();
			while (number > 0)
			{
				number /= 1000;
				if (number > 0)
					stack.Enqueue(number);
			}

			return stack;
		}
	}
}