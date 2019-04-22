namespace HorribleSubsRenamer.Extensions
{
    internal static class StringExtensions
    {
        internal static string Between(this string input, string start, string end)
        {
            int startPos = input.IndexOf(start);
            int endPos = input.LastIndexOf(end);

            if (startPos == -1)
                return string.Empty;

            if (endPos == -1)
                return string.Empty;

            int adjustedPosA = startPos + start.Length;

            if (adjustedPosA >= endPos)
                return string.Empty;

            return input.Substring(adjustedPosA, endPos - adjustedPosA);
        }
    }
}
