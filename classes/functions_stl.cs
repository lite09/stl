using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace stl.classes
{
    class functions_stl
    {
        public static string make_description(List<string> source_description, Dictionary<string, string> key_words)
        {
            if (source_description == null || source_description.Count == 0)
                return null;

            //  удаление строк без наиденных данных
            //string []time_d = new string[source_description.Count]; time_d = source_description.ToArray();
            
            List<string> time_description = source_description.ToList();

            time_description.RemoveAll(i => {
                foreach (var key in key_words) if (Regex.IsMatch(i, "{" + key.Key + "}"))
                        return false;

                return true;
            });

            //  обновление кодовых слов значениями
            foreach (var k_word in key_words)
                for (int l = 0; l < time_description.Count; l++)
                    time_description[l] = time_description[l].Replace("{" + k_word.Key.ToUpper() + "}", k_word.Value);

            string description = string.Join("", time_description.ToArray());

            return description;
        }

        static public string get_property(string property, Options op)
        {
            if (property == "height_pack")
            {
            }
            try
            {
                FieldInfo i = typeof(Options).GetField(property.ToLower());
                if (i == null)
                    return "";

                object value = i.GetValue(op);//.ToString();
                if (value == null)
                    return "";

                string s = value.ToString();
                s = s.ToString(CultureInfo.InvariantCulture);
                //return value.ToString();
                return s;
            }
            catch { return ""; }
        }

        public static string[,] get_sim_to_ch(string file)
        {
            try
            {
                string txt = System.IO.File.ReadAllText(file, System.Text.Encoding.UTF8); txt += "\r\n";
                string[] lines = Regex.Matches(txt, "(.*)\\r\\n").Cast<Match>().Select(l => l.Value.Trim()).ToArray();
                string[] ch = new string[2];
                int sum = 0;
                List<string[]> l_sim_to_ch = new List<string[]>();

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "") continue;
                    sum++;
                    ch[0] = Regex.Match(lines[i], "(^\\S*)\\|").Groups[1].Value;
                    ch[1] = Regex.Match(lines[i], @"\S*\|(\S+)$").Groups[1].Value;
                    l_sim_to_ch.Add(new string[] { ch[0], ch[1] });
                }

                string[,] sim_to_ch = new string[sum, 2];
                for (int i = 0; i < l_sim_to_ch.Count; i++)
                {
                    sim_to_ch[i, 0] = l_sim_to_ch[i][0];
                    sim_to_ch[i, 1] = l_sim_to_ch[i][1];
                }

                return sim_to_ch;
            }
            catch { System.Windows.Forms.MessageBox.Show("Не удалось прочитать символы подстановки"); return null; }
        }
    }
}
