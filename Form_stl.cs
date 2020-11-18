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
    public partial class Form_stl : Form
    {
        public Form_stl()
        {
            InitializeComponent();
        }

        private void таблицаСвойствToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            make_op(@"C:\Users\и\source\repos\stl\bin\Debug\xml\kanctovary.xml", @"C:\Users\и\source\repos\stl\bin\Debug\csv", @"C:\Users\и\Desktop\", @"C:\Users\и\source\repos\stl\bin\Debug\cfg");
        }
        public void make_op(string xml, string folder_options, string save, string cfg)
        {
            settings sets = new settings(cfg + "\\Таблица свойств.csv", cfg + "\\Соотнесение категорий.csv", cfg + "\\id категории.csv", cfg + "\\Формирование розничных цен.csv", cfg + "\\Таблица множителей габаритов и массы.csv", cfg);
            //var l = sets.get_coefficient(9);
            //var cat = sets.get_name_of_category(22941);
            List<Options> options = new List<Options>();                        // опции всех файлов
            List<int> index = new List<int>();                                  // список индексов из данных парсера
            string[] files_opions = Directory.GetFiles(folder_options);       // список файлов
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
                StringBuilder normal_file = new StringBuilder();
                title_tmp.Clear();
                //normal_file = "";
                name_f = Path.GetFileNameWithoutExtension(file_option);
                string fileText = System.IO.File.ReadAllText(file_option, Encoding.Default);

                // -------------------------------------------- Заголовок --------------------------------------------
                Regex sub_string = new Regex(";");

                words = get_line.Match(fileText).Groups[1].Value;

                string[] title_l = sub_string.Split(words);
                List<int> not_found_index = new List<int>();       // Индексы столбцов не найденных в заголовке

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
                    {
                        not_found_index.Add(il);
                        unload.Add(title_l[il]);      // не найденные свойства
                    }
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
                    if (i == 5)
                    {
                        title.Add("PROIZVODITEL"); title.Add("DESCRIPTION"); title.Add("LENGTH_PACK"); title.Add("WIDTH_PACK"); title.Add("HEIGHT_PACK"); title.Add("WEIGHT_V"); title.Add("WEIGHT");
                        title.Add("DELIVERY_PACKAGE_TYPE"); title.Add("DELIVERY_PACKAGE");
                    }
                }
                //sb.Append(option + ";");

                //sb.Append("\r\n");
                // -------------------------------------------- Заголовок --------------------------------------------


                foreach (string item in title)
                    normal_file.Append(item + ";");
                normal_file.Append("\r\n");  // файл с правильным заголовком

                Regex manual_get_line = new Regex("https(.*)", RegexOptions.Multiline);
                MatchCollection lines = get_line.Matches(fileText);
                StringBuilder str_bl = new StringBuilder();
                string buf;



                for (i = 1; i < lines.Count; i++)
                {
                    if (i == lines.Count - 1) break;
                    if (manual_get_line.IsMatch(lines[i + 1].Value))
                        str_bl.Append(lines[i]);
                    else
                    {
                        buf = lines[i].Value; buf = buf.Replace("\r\n", "__"); str_bl.Append(buf);
                    }
                }

                lines = get_line.Matches(str_bl.ToString());
                //File.WriteAllText("lines.csv", str_bl.ToString(), Encoding.Default);

                Regex r_celas = new Regex(";");
                string rn;
                foreach (Match line in lines)
                {
                    string[] cells = r_celas.Split(line.Value);
                    buf = "";
                    for (i = 0; i < cells.Length; i++)
                    {
                        if (i == 5) buf += ";;;;;;;;;";
                        if (sets.equal(i, not_found_index))
                            continue;
                        buf += cells[i] + ";";
                    }
                    normal_file.Append(buf);
                    rn = normal_file[normal_file.Length - 3].ToString() + normal_file[normal_file.Length - 2];
                    if (rn != "\r\n")
                        normal_file.Append("\r\n");
                    normal_file.Remove(normal_file.Length - 1, 1);
                }

                MatchCollection time = get_line.Matches(normal_file.ToString());

                if (save_uload != "")
                {
                    File.WriteAllText("unload.txt", save_uload);
                    MessageBox.Show("Не все поля заголовка были найденны.\r\nНедостающие свойства сохнаненны в файл unload.txt");
                }

                File.WriteAllText(name_f + ".csv", normal_file.ToString(), Encoding.GetEncoding(1251));

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

            // удаляем временные файлы
            foreach (string file_option in files_opions)
                File.Delete(Path.GetFileName(file_option));

            foreach (var tl in title) sb.Append(tl + ";");
            sb.Remove(sb.Length - 1, 1);        // удаление последнего разделительного символа
            sb.Append("\r\n");

            //var hi = options.Find(l => l.artnumber == "1637081");
            //string col = hi.kolichestvo_cvetov;

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
            //string[] files_xml = Directory.GetFiles("xml");
            //Get_xml xml_data = new Get_xml(files_xml[0], index);
            Get_xml xml_data = new Get_xml(xml, index);

            // --------------------------- формирование габаритов и веса --------------------------
            foreach (Options option in options)
                option.get_abc_weight(sets.coefficients_volume_and_mass, ref xml_data.get_xml_data);
            // --------------------------- формирование габаритов и веса --------------------------

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
                string price = Convert.ToString(time_xml_line.price * sets.get_coefficient(time_xml_line.price));
                string artnum = option.artnumber;
                string material = option.material;
                string features = option.features;
                string category = sets.get_name_of_category(time_xml_line.category);

                string description =
                    "<H2>" + short_name + "</H2>" +
                    "<p>" + name + " ";
                if (artnum != "") description += "артикул " + artnum + " ";
                description += "по цене " + price + " руб. в наличии на складе.</p>";
                if (proisvoditel != "") description += "<p>Производитель — " + proisvoditel + "</p>";

                if (strana_prois != "") description += "<p>Страна производитель — " + strana_prois + "</p>";
                if (material != "") description += "<p>Сделано из: " + material + "</p>";
                if (features != "") description += "<p>Особенности: " + features + "</p>";
                description += "<p>Мы предлагаем " + category + " ведущих Российских производителей, а также налажена поставка товаров из Китая и Германии. Приобрести данный товар Вы можете on-line на нашем сайте, позвонив по телефону — 8-800-2000-600, а также в офисе в Москве.</p>";

                option.description = description;

                // --------------------------- формироание описания ---------------------------
                char[] se = { '_', '_' };
                foreach (string tl in title)
                {
                    string value = option.get_property(tl.ToLower(), option);

                    if (tl == "WEIGHT_V_GR" && option.WEIGHT_V_GR != "")
                    {
                    }

                    // ------------------------------------------- игнорирование дубля ------------------------------------------- 
                    string[] cut_double = { "" };
                    if (tl == "SERIYA" || tl == "PRICE_FOR_THE_ONE" || tl == "PRICE_FOR" || tl == "PRICE_FOR_" || tl == "SOSTAV")
                    {
                        //words = get_line.Match(option.get_property(tl.ToLower(), option)).Groups[1].Value;
                        if (value != "")
                            cut_double = value.Split(se);

                        sb.Append(cut_double[0] + ";");
                    }
                    // ------------------------------------------- игнорирование дубля -------------------------------------------
                    else if (tl == "LENGTH_PACK" || tl == "WIDTH_PACK" || tl == "HEIGHT_PACK" || tl == "WEIGHT_V" || tl == "WEIGHT")
                    {
                        if (value == "0")
                            sb.Append(";");
                        else
                        {
                            sb.Append(value + ";");
                        }
                    }
                    else if (tl == "DIAMETR_PISHUSHCHEGO_UZLA_MM")
                    {
                        value = value.Replace(".", ",");
                        sb.Append(value + ";");
                    }
                    else
                        sb.Append(value + ";");
                }
                sb.Remove(sb.Length - 1, 1);        // удаление последнего разделительного символа
                sb.Append("\r\n");
                //string hi = nameof(option);
            }

            // сохраняем говый файл
            File.WriteAllText(save + "\\" + Path.GetFileNameWithoutExtension(xml) + ".csv", sb.ToString(), Encoding.GetEncoding(1251));
            // --------------------------- выборка из массива классов свойств в string bufer для созранения в текстовый файл --------------------------- 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.PerformClick();
        }
    }
}

public partial class settings
{
    public List<string[]> options = new List<string[]>();
    public List<string> prepositions = new List<string> { "A"/*латиница*/, "А" };                                                       // список предлогов для обрывки фразы
    public List<string> stop_words = new List<string> { "d\\s*=", "h\\s*=", "r\\s*=", "А\\.", "№", "SchE", "ш\\." };                    // список стоп слов для обрывки фразы
    public List<float[]> coefficients = new List<float[]> { };                                                                          // список коэффициентов
    List<string[]> categoryes = new List<string[]>();                                                                                   // список категорий
    List<string[]> name_of_categoryes = new List<string[]>();                                                                           // список соотношений имени и кода категорий
                                                                                                                                        // Коэффициенты для габаритов и массы
    public List<coefficient_of_package>
        coefficients_volume_and_mass = new List<coefficient_of_package>();
    public struct coefficient_of_package
    {
        public int category_id; public float coefficient_of_massa; public float coefficient_of_dimensions;
    }

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

    public settings(string file_options, string categoryes, string file_get_name_of_category, string file_coefficients, string file_of_coefficients)
    {
        add_options(file_options);
        get_category(categoryes);
        get_name_of_category(file_get_name_of_category);
        get_coefficients(file_coefficients);
        get_coefficients_vol_mass(file_of_coefficients);
        get_stop_words();
    }

    public settings(string file_options, string categoryes, string file_get_name_of_category, string file_coefficients, string file_of_coefficients, string cfg)
    {
        add_options(file_options);
        get_category(categoryes);
        get_name_of_category(file_get_name_of_category);
        get_coefficients(file_coefficients);
        get_coefficients_vol_mass(file_of_coefficients);
        get_stop_words(cfg);
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
    private void get_stop_words(string cfg = "")
    {
        string stop_wrd = "";
        if (cfg != "")
            stop_wrd = File.ReadAllText(cfg + "\\stop words.csv", Encoding.Default);
        else
            stop_wrd = File.ReadAllText("stop words.csv", Encoding.Default);
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
    private void get_category(string file_category)
    {
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
    private void get_name_of_category(string file_name_of_category)
    {
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
    public float get_coefficient(float price)
    {
        foreach (float[] range in coefficients)
            if ((price >= range[0]) && (price <= range[1]))
                return range[2];

        MessageBox.Show("Коэффициент не был найден");
        return 2;
    }
    private void get_coefficients_vol_mass(string file_of_coefficients)
    {
        string cf = null;
        try { cf = File.ReadAllText(file_of_coefficients, Encoding.Default); }
        catch { MessageBox.Show("Не удалось загрузить файл с коэффициентами"); }

        Regex get_line = new Regex("(.*)\r\n");
        MatchCollection words = get_line.Matches(cf);
        Regex sub_string = new Regex(";");
        string[] line; int i = 0;

        foreach (Match m in words)
        {
            if (i == 0) { i++; continue; }
            line = sub_string.Split(m.Groups[1].Value);
            coefficient_of_package info = new coefficient_of_package();
            if (line[0] != "")
            {
                info.category_id = Convert.ToInt32(line[0]);
                info.coefficient_of_massa = Convert.ToSingle(line[1]);
                info.coefficient_of_dimensions = Convert.ToSingle(line[2]);
            }
            if (line[0] != "") coefficients_volume_and_mass.Add(info);
        }
    }
    public string get_name_of_category(int category_xml)
    {
        int category = 9;
        string category_Str = "";
        // категория обновленна, отличная от файла хмл, взятая из фаила соотнесение категории
        try { category = Convert.ToInt32(categoryes.Find(cat => Convert.ToInt32(cat[0]) == category_xml)[1]); }
        catch { return "{категория не найдена}"; }

        // назваие категории из фаила соотнесение категории соотнесенная по номеру
        try { category_Str = name_of_categoryes.Find(cat => Convert.ToInt32(cat[0]) == category)[1]; }
        catch { return "{категория не найдена}"; }
        if (category_Str != "")
            return category_Str;

        return "{категория не найдена}";
    }
    public bool equal(int i, List<int> list)
    {
        foreach (int index in list)
            if (i == index) return true;

        return false;
    }
}