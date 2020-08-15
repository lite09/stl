using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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

            foreach (string file_option in files_opions)
            {
                string fileText = System.IO.File.ReadAllText(file_option, Encoding.Default);
                Regex get_line = new Regex("(.*)\r\n");
                Match words = get_line.Match(fileText);
                Regex sub_string = new Regex(";");
                
                string []title = sub_string.Split(words.Value);

                for (int i = 0; i < title.Length; i++)
                    foreach (string[] it in l)
                        if (title[i] == "\"" + it[0] + "\"")
                            title[i] = it[1];

                using (var reader = new StreamReader(file_option, Encoding.GetEncoding(1251)))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";

                    var l = csv.GetRecords<option_csv>();
                    options_csv = l.ToList();
                }
            }
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