using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace stl.classes
{
    class functions_stl
    {
        public static string make_description(string source_description, Dictionary<string, string> key_words)
        {
            if (source_description == null || source_description == "")
                return null;

            Regex getline = new Regex(@"(<.[^/]*/\S[^<]+>*)");
            List<string> lines_description = new List<string>();

            MatchCollection lines = Regex.Matches(source_description.Replace("\r\n", ""), getline.ToString(), RegexOptions.Multiline);
            lines_description = lines.Cast<Match>().Select(m => m.Value).ToList();

            foreach (var k_word in key_words)
            {
                if (k_word.Value == "" || k_word.Value == null)
                {
                    lines_description.RemoveAll(i => Regex.IsMatch(i.ToLower(), k_word.Key));
                    continue;
                }
            }

            //  обновление кодовых слов значениями
            foreach (var k_word in key_words)
                for (int l = 0; l < lines_description.Count; l++)
                    lines_description[l] = lines_description[l].Replace("{" + k_word.Key.ToUpper() + "}", k_word.Value);

            string description = string.Join("", lines_description.ToArray());



            /*if (product_color == "")
                lines_description.RemoveAll(i => Regex.IsMatch(i, words[3]));

            description = osob_cveta != ""?description.Replace("{OSOBENNOSTI_CVETA}", @"<br>&nbsp" + osob_cveta):description.Replace("{OSOBENNOSTI_CVETA}", osob_cveta);
            description = description.Replace("{ID_CATEGORY}", category);*/

            return description;
        }
    }
}
