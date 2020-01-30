using System;
using System.Collections.Generic;
using System.Linq;
using IntegerConverstionService.Enums;
using IntegerConverstionService.Extension;
using IntegerConverstionService.Model;

namespace IntegerConverstionService.LogicArray
{
    public static class Frac20
    {
	    private static readonly string[] frac20 =
	    {
		    "", "один", "два", "три", "четыре", "пять", "шесть",
		    "семь", "восемь", "девять", "десять", "одиннадцать",
		    "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
		    "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
	    };
	   private static readonly List<QuantitativeNumber> SpecialCaseFor14 =
		  new List<QuantitativeNumber>
		  {
			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Nominative,StrValue = "один", Index = 1},
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Nominative,StrValue = "одна", Index = 1 },
			    {new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Nominative,StrValue = "одно", Index = 1 } },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Genitive,StrValue = "одного", Index = 1},
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Genitive,StrValue = "одной", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Genitive,StrValue = "одного", Index = 1 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Dative,StrValue = "одному", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Dative,StrValue = "одной", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Dative,StrValue = "одному", Index = 1 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Accusative,StrValue = "один", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Accusative,StrValue = "одну", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Accusative,StrValue = "один", Index = 1 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Instrumental,StrValue = "одним", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Instrumental,StrValue = "одной", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Instrumental,StrValue = "одним", Index = 1 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Prepositional,StrValue = "одном", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Prepositional,StrValue = "одной", Index = 1 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Prepositional,StrValue = "одном", Index = 1 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Nominative,StrValue = "два", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Nominative,StrValue = "две", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Nominative,StrValue = "два", Index = 2 },


			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Genitive,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Genitive,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Genitive,StrValue = "двух", Index = 2 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Dative,StrValue = "двум", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Dative,StrValue = "двум", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Dative,StrValue = "двум", Index = 2 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Accusative,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Accusative,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Accusative,StrValue = "двух", Index = 2 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Instrumental,StrValue = "двумя", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Instrumental,StrValue = "двумя", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Instrumental,StrValue = "двумя", Index = 2 },

			    new QuantitativeNumber {Kind = Kind.Masculine, SubjCase=SubjectiveCase.Prepositional,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.FeminineGender, SubjCase=SubjectiveCase.Prepositional,StrValue = "двух", Index = 2 },
			    new QuantitativeNumber {Kind = Kind.NeuterGender, SubjCase=SubjectiveCase.Prepositional,StrValue = "двух", Index = 2 },

			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Nominative,StrValue = "три", Index = 3 },
			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Genitive,StrValue = "трех", Index = 3 },
			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Dative,StrValue = "трем", Index = 3 },
			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Accusative,StrValue = "трех", Index = 3 },
			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Instrumental,StrValue = "тремя", Index = 3 },
			    new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Prepositional,StrValue = "трех", Index = 3 },


			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Nominative,StrValue = "четыре", Index = 4 },
			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Genitive,StrValue = "четырех", Index = 4 },
			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Dative,StrValue = "четырем", Index = 4 },
			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Accusative,StrValue = "четырех", Index = 4 },
			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Instrumental,StrValue = "четырьмя", Index = 4 },
			  new QuantitativeNumber {Kind = Kind.None, SubjCase=SubjectiveCase.Prepositional,StrValue = "четырех", Index = 4 },
		  };

	    private static readonly string[] Frac20Base =
	    {
		    "", "", "", "", "", "пяти", "шести", "семи", "восьми", "девяти", "десяти", "одиннадцати", "двенадцати",
		    "тринадцати",
		    "четырнадцати", "пятнадцати", "шестанадцати", "семнадцати", "восемнадцати", "девятнадцати"
	    };

	    public static string GetQuantitativeNumber(int number, Func<int, int> funct,
		    SubjectiveCase subjectiveCase = SubjectiveCase.Nominative, Kind kind = Kind.Masculine)
	    {
		    var index = funct(number);
		    if (index >= 5 && index < 19)
		    {
			    if (subjectiveCase == SubjectiveCase.Genitive || subjectiveCase == SubjectiveCase.Dative ||
			        subjectiveCase == SubjectiveCase.Prepositional)
			    {
				    return Frac20Base[index].AddSpace();
			    }

			    if (subjectiveCase == SubjectiveCase.Instrumental)
				    return frac20[index].AddSymbolWidthSpace("ю");
		    }

		    var my = SpecialCaseFor14.Select(content => content.Index).Contains(index)
			    ? SpecialCaseFor14
				    .Where(content => content.Index == index)
				    .Where(content => content.Kind == kind || content.Kind == Kind.None)
				    .Where(content => content.SubjCase == subjectiveCase)
				    .Select(content => content.StrValue)
				    .FirstOrDefault()
			    : frac20[index];

		    return my.AddSpace();

	    }
    }
}
