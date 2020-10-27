using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace stl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void таблицаСвойствToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings sets = new settings();

            //string filename = ;
            List<Options> options = new List<Options>();        // опции всех файлов
            var l = sets.add_options("cfg//Таблица свойств.csv");  // путь к папке с файлами
            string[] files_opions = Directory.GetFiles("sl");   // список файлов
            string name_f = "";
            string save_uload = "";
            List<string> title_tmp = new List<string>();
            List<string> title = new List<string>();
            List<string> unload = new List<string>();
            Regex get_line = new Regex("(.*)\r\n", RegexOptions.Multiline);
            string words = "";
            StringBuilder sb = new StringBuilder();

            foreach (string file_option in files_opions)
            {
                string normal_file = "";
                title_tmp.Clear();
                //normal_file = "";
                name_f = Path.GetFileNameWithoutExtension(file_option);
                string fileText = System.IO.File.ReadAllText(file_option, Encoding.Default);

                // -------------------------------------------- Заголовок --------------------------------------------
                Regex sub_string = new Regex(";");

                words = get_line.Match(fileText).Groups[1].Value;

                string[] title_l = sub_string.Split(words);

                for (int il = 0; il < title_l.Length; il++)
                {
                    bool fine = false;
                    foreach (string[] it in l)
                        if (title_l[il] == "\"" + it[0] + "\"")
                        {
                            fine = true;
                            title_tmp.Add(it[1]);   // заголовок из наденных свойств
                        }

                    if (!fine)
                        unload.Add(title_l[il]);      // не найденные свойства
                }

                foreach (string s in unload)
                {
                    save_uload += s + "\r\n";
                }


                foreach (string option in title_tmp)
                {
                    bool is_tl = false;
                    foreach (string tl in title)
                    {
                        if (option == tl)
                        {
                            is_tl = true;
                            break;
                        }
                    }
                    if (!is_tl)
                        title.Add(option);
                }
                //sb.Append(option + ";");

                //sb.Append("\r\n");
                // -------------------------------------------- Заголовок --------------------------------------------


                foreach (var item in title_tmp)
                    normal_file += item + ";";

                normal_file += "\r\n";  // файл с правильным заголовком

                MatchCollection lines = get_line.Matches(fileText);
                int i = 0;
                foreach (Match line in lines)
                {
                    if (i == 0) { i++; continue; }
                    normal_file += line;
                }
                //}

                if (save_uload != "")
                {
                    File.WriteAllText("unload.txt", save_uload);
                    MessageBox.Show("Не все поля заголовка были найденны.\r\nНедостающие свойства сохнаненны в файл unload.txt");
                }

                File.WriteAllText(name_f + ".csv", normal_file, Encoding.GetEncoding(1251));

                List<Options> options_values = new List<Options>();
                using (var reader = new StreamReader(name_f + ".csv", Encoding.GetEncoding(1251)))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.Encoding = Encoding.GetEncoding(1251);
                    //csv.Configuration.MemberTypes = CsvHelper.Configuration.MemberTypes.Fields;
                    //csv.Configuration.RegisterClassMap<map>();

                    var li = csv.GetRecords<Options>();
                    options_values = li.ToList();
                    options.AddRange(options_values);
                }

                //using (var writer = new StreamWriter("file.csv"/*, Encoding.GetEncoding(1251)*/))
                //using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                //{
                //    csv.WriteRecords(options);
                //}
            }

            foreach (var tl in title) sb.Append(tl + ";");
            sb.Append("\r\n");

            // --------------------------- выборка из массива классов свойств в string bufer для сохранения в текстовый файл --------------------------- 
            foreach (Options option in options)
            {
                foreach (string tl in title)
                {
                    //Type t = typeof(Options);
                    //var fld = typeof(Options).GetField(tl.ToLower()).GetValue(option);
                    //var str = fld.GetValue(option);
                    if (tl == "EFFEKT" && option.EFFEKT != "")
                    {
                        //
                    }

                    // ------------------------------------------- игнорирование дубля ------------------------------------------- 
                    if (tl == "SERIYA" || tl == "PRICE_FOR_THE_ONE" || tl == "PRICE_FOR" || tl == "PRICE_FOR_" || tl == "SOSTAV")
                    {
                        words = get_line.Match(option.get_property(tl.ToLower(), option)).Groups[1].Value;
                        sb.Append(words + ";");
                    }
                    // ------------------------------------------- игнорирование дубля ------------------------------------------- 
                    else
                    {
                        string id = option.get_property(tl.ToLower(), option);
                        sb.Append(option.get_property(tl.ToLower(), option) + ";");
                    }
                }
                sb.Append("\r\n");
                //string hi = nameof(option);
            }
            foreach (string file_option in files_opions)
                File.Delete(Path.GetFileName(file_option));
            File.WriteAllText("вывод.csv", sb.ToString(), Encoding.GetEncoding(1251));
            // --------------------------- выборка из массива классов свойств в string bufer для созранения в текстовый файл --------------------------- 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

public partial  class settings
{
    List<string[]> options;

    public settings() {
        options = new List<string[]>();
    }

    public List<string[]> add_options(string file_name)
    {
        string fileText = System.IO.File.ReadAllText(file_name, Encoding.Default);

        Regex get_line = new Regex("(.*)\r\n");
        MatchCollection words = get_line.Matches(fileText);
        Regex sub_string = new Regex(";");
        string[] line;

        int i = 0;
        foreach (Match m in words)
        {
            if (i == 0) { i++; continue; }

            line = sub_string.Split(m.Groups[1].Value);
            string[] ops = new string[2];
            if (line[0] != "")
            {
                ops[0] = line[0];
                ops[1] = line[1];
                options.Add(ops);
            }
        }

        return options;
    }
}