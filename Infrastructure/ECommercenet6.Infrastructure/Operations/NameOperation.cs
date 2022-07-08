namespace ECommercenet6.Infrastructure.Operations;

public  static class NameOperation
{
    public static string CharacterRegulatiry(string name) =>
        name.Replace("\'", "").Replace("'", "").Replace("^", "").Replace("+", "").Replace("%", "").Replace("&", "")
            .Replace("(", "").Replace(")", "").Replace("=", "").Replace("?", "").Replace("@", "").Replace("#", "")
            .Replace("~", "").Replace(",", "").Replace(";", "").Replace(":", "").Replace(".", "-").Replace("Ö", "O")
            .Replace("ö", "o").Replace("Ü", "U").Replace("ü", "u").Replace("ı", "i").Replace("I", "İ").Replace("ğ", "g")
            .Replace("Ğ", "g").Replace("&", "").Replace("ş", "s").Replace("Ş", "S").Replace("Ç", "C").Replace("ç", "c")
            .Replace("ç", "c").Replace("<", "").Replace(">", "").Replace("!", "").Replace("|", "");






}