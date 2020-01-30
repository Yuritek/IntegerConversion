using System;
using IntegerConverstionService;

namespace ConvertInt
{
    class Program
    {
	   static void Main(string[] args)
	   {
		   while (true)
		   {
			   Console.WriteLine("Результат:" + new RusNumber().SumProp(Convert.ToInt32(Console.ReadLine())));
		   }
		  
	   }
    }

    
}
