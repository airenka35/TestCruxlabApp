using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {
        var countOfValidPassword = 0;
        try
        {
            StreamReader sr = new StreamReader("C:\\Users\\airen_peux7sh\\Desktop\\TextCruxlab.txt");

            var line = sr.ReadLine();

            while (line != null && !line.Equals(string.Empty))
            {
                line = RemoveWhitespace(line);

                var letterToFind = line.Substring(0, 1);
                int.TryParse(GetSubstrOrEmpty(line, "-", string.Empty), out var symbolFrom);
                int.TryParse(GetSubstrOrEmpty(line, ":", "-"), out var symbolTo);
                var searchLine = GetSubstrOrEmpty(line, string.Empty, ":");

                var countOfMatches = Regex.Matches(searchLine, letterToFind).Count;
             
                if (countOfMatches >= symbolFrom && countOfMatches <= symbolTo)
                    countOfValidPassword++;

                line = sr.ReadLine();
            }

            sr.Close();

            Console.WriteLine("Count of valid passwords:{0}", countOfValidPassword);

            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
    }

    static string GetSubstrOrEmpty(string text, string stopAt, string startAt)
    {
        if (!stopAt.Equals(string.Empty) && !startAt.Equals(string.Empty))
        {
            int charLocationStopAt = text.IndexOf(stopAt, StringComparison.Ordinal);
            int charLocationStartAt = text.IndexOf(startAt, StringComparison.Ordinal);

            if (charLocationStopAt > 0 && charLocationStartAt > 0)
                return text.Substring(charLocationStartAt + 1, charLocationStopAt - charLocationStartAt - 1);
        }

        if (!stopAt.Equals(string.Empty))
        {
            int charLocationStopAt = text.IndexOf(stopAt, StringComparison.Ordinal);

            if (charLocationStopAt > 0)
                return text.Substring(1, charLocationStopAt - 1);

        }
        if (!startAt.Equals(string.Empty))
        {
            int charLocationStartAt = text.IndexOf(startAt, StringComparison.Ordinal);

            if (charLocationStartAt > 0)
                return text.Substring(charLocationStartAt + 1, text.Length - (charLocationStartAt + 1));
        }

        return string.Empty;
    }
}



