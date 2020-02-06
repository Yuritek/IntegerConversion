namespace IntegerConverstionService.Extension
{
	public static class StringExtension
	{
		public static string AddSpace(this string value)
		{
			return string.Concat(value, " ");
		}

		public static string AddSymbol(this string value, string symbol)
		{
			return string.Concat(value.Trim(), symbol.Trim());
		}

		public static string ReplaceSymbol(this string value, string symbol)
		{
			return value.Substring(0,value.Length-1)+symbol;
		}

		public static string DeleteLastSymbol(this string value)
		{
			return value.Substring(0, value.Length - 1);
		}
    }
}