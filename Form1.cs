﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            settings sets = new settings();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            //string filename = ;
            var l = sets.add_options(openFileDialog.FileName);
            string[] files_opions = Directory.GetFiles("sl");
            string normal_file = "";
            string name_f = "";
            string save_uload = "";
            List<string> title_tmp = new List<string>();
            int i_tittle = 0;
            List<string> unload = new List<string>();
            Regex get_line = new Regex("(.*)\r\n", RegexOptions.Multiline);
            string words = "";
            StringBuilder sb = new StringBuilder();

            foreach (string file_option in files_opions)
            {
                //normal_file = "";
                name_f += "_hi_" + Path.GetFileNameWithoutExtension(file_option);
                string fileText = System.IO.File.ReadAllText(file_option, Encoding.Default);
                Regex sub_string = new Regex(";");
                words = get_line.Match(fileText).Groups[1].Value;

                string[] title = sub_string.Split(words);

                for (int il = 0; il < title.Length; il++)
                {
                    bool fine = false;
                    foreach (string[] it in l)
                        if (title[il] == "\"" + it[0] + "\"")
                        {
                            title[il] = it[1]; fine = true;
                        }

                    if (!fine)
                        unload.Add(title[il]);
                }

                if (i_tittle == 0)
                {
                    foreach (string str in title) title_tmp.Add(str); i_tittle++;
                }

                foreach (string s in unload)
                {
                    save_uload += s + "\r\n";
                }

                foreach (var item in title)
                    normal_file += item + ";";

                normal_file += "\r\n";

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
                }

                foreach (string option in title_tmp) sb.Append(option + ";"); sb.Append("\r\n");


                foreach (Options option in options_values)
                {
                    foreach (string tl in title_tmp)
                    {
                        //Type t = typeof(Options);
                        //var fld = typeof(Options).GetField(tl.ToLower()).GetValue(option);
                        //var str = fld.GetValue(option);
                        if (tl == "SERIYA" || tl == "PRICE_FOR_THE_ONE" || tl == "PRICE_FOR" || tl == "PRICE_FOR_")
                        {
                            words = get_line.Match(option.get_property(tl.ToLower(), option)).Groups[1].Value;
                            sb.Append(words + ";");
                        }
                        else
                            sb.Append(option.get_property(tl.ToLower(), option) + ";");
                    }
                    sb.Append("\r\n");
                    //string hi = nameof(option);
                }
            }

            File.WriteAllText("вывод.csv", sb.ToString(), Encoding.GetEncoding(1251));

            //using (var writer = new StreamWriter("test.csv"))
            //using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            //{
            //    csv.WriteRecords(ptions);
            //}

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