using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace stl.classes
{
    class functions_stl
    {
        public static string make_description(string source_description, object[] info)
        {
            if (source_description == null || source_description == "")
                return null;

            Regex getline = new Regex(@"(<.[^/]*/\S[^<]+>*)");
            List<string> lines_description = new List<string>();
            string[] words = { "proizvoditel", "STRANA_PROIZVODITEL", "MATERIAL", "PRODUCT_COLOR", "OSOBENNOSTI_CVETA" };


            string name = Convert.ToString(info[0]);
            string short_name = Convert.ToString(info[1]);
            string proisvoditel = Convert.ToString(info[2]);    //
            string strana_prois = Convert.ToString(info[3]);    //
            string price = Convert.ToString(info[4]);
            string artnum = Convert.ToString(info[5]);
            string material = Convert.ToString(info[6]);        //
            string category = Convert.ToString(info[7]);
            string product_color = Convert.ToString(info[8]);
            string osob_cveta = Convert.ToString(info[9]);

            MatchCollection lines = Regex.Matches(source_description.Replace("\r\n", ""), getline.ToString(), RegexOptions.Multiline);
            lines_description = lines.Cast<Match>().Select(m => m.Value).ToList();

            if (proisvoditel == "")
                lines_description.RemoveAll(i => Regex.IsMatch(i, words[0]));
            if (strana_prois == "")
                lines_description.RemoveAll(i => Regex.IsMatch(i, words[1]));
            if (material == "")
                lines_description.RemoveAll(i => Regex.IsMatch(i, words[2]));
            if (product_color == "")
                lines_description.RemoveAll(i => Regex.IsMatch(i, words[3]));

            string description = string.Join("", lines_description.ToArray());

            description = description.Replace("{NAME}", short_name);
            description = description.Replace("{FULL_NAME}", name);
            description = description.Replace("{PRICE}", price);
            description = description.Replace("{proizvoditel}", proisvoditel);
            description = description.Replace("{STRANA_PROIZVODITEL}", strana_prois);
            description = description.Replace("{MATERIAL}", material);
            description = description.Replace("{PRODUCT_COLOR}", product_color);
            description = osob_cveta != ""?description.Replace("{OSOBENNOSTI_CVETA}", @"<br>&nbsp" + osob_cveta):description.Replace("{OSOBENNOSTI_CVETA}", osob_cveta);
            description = description.Replace("{ID_CATEGORY}", category);

            return description;
        }
    }
}
