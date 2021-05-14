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
    }
}
