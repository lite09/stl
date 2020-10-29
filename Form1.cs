﻿using CsvHelper;
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
            settings sets = new settings("cfg\\Таблица свойств.csv", "cfg\\Соотнесение категорий.csv", "cfg\\id категории.csv", "cfg\\Формирование розничных цен.csv");
            //var l = sets.get_coefficient(9);
            List<Options> options = new List<Options>();            // опции всех файлов
            List<int> index = new List<int>();                      // список индексов из данных парсера
            string[] files_opions = Directory.GetFiles("sl");       // список файлов
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
                    foreach (string[] it in sets.options)
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

                int i = 0;
                foreach (string option in title_tmp)
                {
                    bool is_tl = false; i++;
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
                    if (i == 5) { title.Add("proizvoditel"); title.Add("DESCRIPTION"); }
                }
                //sb.Append(option + ";");

                //sb.Append("\r\n");
                // -------------------------------------------- Заголовок --------------------------------------------


                foreach (var item in title_tmp)
                    normal_file += item + ";";

                normal_file += "\r\n";  // файл с правильным заголовком

                MatchCollection lines = get_line.Matches(fileText);
                i = 0;
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
            }

            foreach (var tl in title) sb.Append(tl + ";");
            sb.Append("\r\n");

            // --------------------------- добавление в список индексов ---------------------------
            foreach (Options option in options)
            {
                try
                {
                    Regex r_id = new Regex("(.*)\\/(\\d*)$");
                    Match m_id = r_id.Match(option.id);
                    int id = Convert.ToInt32(m_id.Groups[2].Value);
                    index.Add(id);
                    option.artnumber = id.ToString();
                }
                catch
                {
                }
            }
            // --------------------------- добавление в список индексов ---------------------------

            // получение данных из хмл файла учитывая только индексы которые есть в списке options
            Get_xml xml_data = new Get_xml("xml\\kanctovary.xml", index);

            //foreach (Options option in options)
            //{
            //    option.proizvoditel = xml_data.get_xml_data.Find(data => data.id == option.artnumber).vendor;
            //}
            //foreach (Xml_offer line_data in xml_data.get_xml_data)
            //{
            //    //
            //}
            // --------------------------- выборка из массива классов свойств в string bufer для сохранения в текстовый файл --------------------------- 
            foreach (Options option in options)
            {
                Xml_offer time_xml_line = xml_data.get_xml_data.Find(data => data.id == option.artnumber);
                option.proizvoditel = time_xml_line.vendor;

                // --------------------------- формироание описания ---------------------------
                string name = time_xml_line.name;
                string short_name = time_xml_line.name_short(time_xml_line.name, sets.prepositions, sets.stop_words);
                string proisvoditel = option.proizvoditel;
                string strana_prois = option.strana_proizvoditel;
                string artnum = option.artnumber;
                string material = option.material;
                string features = option.features;

                // --------------------------- формироание описания ---------------------------

                foreach (string tl in title)
                {

                    if (tl == "proizvoditel" && option.proizvoditel != "")
                    {
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

            // удаляем временные файлы
            foreach (string file_option in files_opions)
                File.Delete(Path.GetFileName(file_option));
            // сохраняем говый файл
            File.WriteAllText("вывод.csv", sb.ToString(), Encoding.GetEncoding(1251));
            // --------------------------- выборка из массива классов свойств в string bufer для созранения в текстовый файл --------------------------- 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }
    }
}

public partial class settings
{
    public List<string[]> options       = new List<string[]>();
    public List<string> prepositions    = new List<string>          { "A"/*латиница*/, "А" };                                           // список предлогов для обрывки фразы
    public List<string> stop_words      = new List<string>          { "d\\s*=", "h\\s*=", "r\\s*=", "А\\.", "№", "SchE",  "ш\\." };     // список стоп слов для обрывки фразы
    public List<float[]> coefficients   = new List<float[]>{};                                                                          // список коэффициентов
    List<string[]> categoryes           = new List<string[]>();                                                                         // список категорий
    List<string[]> name_of_categoryes   = new List<string[]>();                                                                         // список соотношений имени и кода категорий

    public settings()
    {
        get_stop_words();
    }
    public settings(string file_options)
    {
        add_options(file_options);
        get_stop_words();

    }
    public settings(string file_options, string file_categoryes)
    {
        add_options(file_options);
        get_category(file_categoryes);
        get_stop_words();
    }
    public settings(string file_options, string categoryes, string file_coefficients)
    {
        add_options(file_options);
        get_category(categoryes);
        get_coefficients(file_coefficients);
        get_stop_words();
    }

    public settings(string file_options, string categoryes, string file_get_name_of_category, string file_coefficients)
    {
        add_options(file_options);
        get_category(categoryes);
        get_name_of_category(file_get_name_of_category);
        get_coefficients(file_coefficients);
        get_stop_words();
    }

    private void add_options(string file_name)
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
    }

    // загрузка слов для обрезания фразы и предлоги
    private void get_stop_words()
    {
        string stop_wrd = File.ReadAllText("cfg\\stop words.csv", Encoding.Default);
        //richTextBox1.Text = stop_wrd;

        Regex short_name = new Regex("(.*)\r\n");
        MatchCollection words = short_name.Matches(stop_wrd);
        //richTextBox2.Text = words.Count.ToString();

        Regex sub_string = new Regex(";");
        string[] line;

        int i = -1;
        foreach (Match m in words)
        {
            i++;
            if (i == 0) continue;
            line = sub_string.Split(m.Groups[1].Value);
            line[1] = line[1].Replace(":", "\\:");
            line[1] = line[1].Replace("(", "\\(");
            line[1] = line[1].Replace(".", "\\.");
            line[1] = line[1].Replace("=", "\\=");
            line[1] = line[1].Replace(" ", "\\s+");

            if (line[0] != "") prepositions.Add(line[0]);
            if (line[1] != "") stop_words.Add(line[1]);
        }
    }
    private void get_category(string file_category) {
        string catalogs = File.ReadAllText(file_category, Encoding.Default);

        Regex get_line = new Regex("(.*)\r\n");
        MatchCollection words = get_line.Matches(catalogs);
        Regex sub_string = new Regex(";");
        string[] line;

        foreach (Match m in words)
        {
            line = sub_string.Split(m.Groups[1].Value);
            string[] cats = new string[2];
            if (line[0] != "")
            {
                cats[0] = line[0];
                cats[1] = line[1];
            }
            if (line[0] != "") categoryes.Add(cats);
        }
        categoryes.RemoveAt(0);
    }
    private void get_name_of_category(string file_name_of_category) {
        string catalogs = File.ReadAllText(file_name_of_category, Encoding.Default);

        Regex get_line = new Regex("(.*)\r\n");
        MatchCollection words = get_line.Matches(catalogs);
        Regex sub_string = new Regex(";");
        string[] line;

        foreach (Match m in words)
        {
            line = sub_string.Split(m.Groups[1].Value);
            string[] cats = new string[2];
            if (line[0] != "")
            {
                cats[0] = line[0];
                cats[1] = line[1];
            }
            if (line[0] != "") name_of_categoryes.Add(cats);
        }
        name_of_categoryes.RemoveAt(0);
    }
    private void get_coefficients(string file_coefficient)
    {
        string catalogs = File.ReadAllText(file_coefficient, Encoding.Default);

        Regex get_line = new Regex("(.*)\r\n");
        MatchCollection words = get_line.Matches(catalogs);
        Regex sub_string = new Regex(";");
        string[] line;

        foreach (Match m in words)
        {
            line = sub_string.Split(m.Groups[1].Value);
            float[] coefficient = new float[3];
            if (line[0] != "")
            {
                coefficient[0] = Convert.ToSingle(line[0]);
                coefficient[1] = Convert.ToSingle(line[1]);
                coefficient[2] = Convert.ToSingle(line[2], CultureInfo.InvariantCulture);
            }
            if (line[0] != "") coefficients.Add(coefficient);
        }
    }
    public float get_coefficient(int price)
    {
        foreach (float[] range in coefficients)
            if ((price >= range[0]) && (price <= range[1]))
                return range[2];

        MessageBox.Show("Коэффициент не был найден");
        return 2;
    }
    public string get_name_of_category(int category_xml)
    {
        return "category";
    }
}