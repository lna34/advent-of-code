public static class StringExtension
{
    public static string ReplaceOccurences(this string s, (string stringToBeReplaced, string replacingString)[] replacements)
    {
        foreach (var to_replace in replacements)
        {
            s = s.Replace(to_replace.stringToBeReplaced, to_replace.replacingString);
        }
        return s;
    }
}