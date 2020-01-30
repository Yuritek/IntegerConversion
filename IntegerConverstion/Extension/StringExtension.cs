namespace IntegerConverstionService.Extension
{
	public static class StringExtension
	{
		public static string AddSpace(this string value)
		{
			return string.Concat(value, " ");
		}

		public static string AddSymbolWidthSpace(this string value, string symbol)
		{
			return string.Concat(value, symbol, " ");
		}
	}
}