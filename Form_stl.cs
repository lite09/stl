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

        public void make_op(object ob)
        {
            object[] inf = ob as object[];
            string xml = Convert.ToString(inf[0]);
            string folder_options = Convert.ToString(inf[1]);
            string save = Convert.ToString(inf[2]);
            cfg_data cfg = (cfg_data)inf[3];
            string cfg_folder = Convert.ToString(inf[4]);
            string tmpl_description = Convert.ToString(inf[5]);

            const uint shift = 2;

            settings sets = new settings(/*xml, */folder_options, save, cfg, cfg_folder);
            List<Options> options = new List<Options>();                        // опции всех файлов
            List<int> index = new List<int>();                                  // список индексов из данных парсера

            string[] files_opions = Directory.GetFiles(folder_options);         // список файлов
            if (files_opions.Length == 0)
                return;

            string name_f = "";
            string save_uload = "";

            List<string> title_tmp = new List<string>();
            List<string> title = new List<string>();
            List<string> unload = new List<string>();

            Regex get_line = new Regex("(.+)$", RegexOptions.Multiline);
            string words = "";
            StringBuilder sb = new StringBuilder();

            foreach (string file_option in files_opions)
            {
                StringBuilder normal_file = new StringBuilder();
                title_tmp.Clear();
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
                    if (il == shift)
                    {
                        /*title.Add("PROIZVODITEL"); */
                        title_tmp.Add("NAME"); title_tmp.Add("FULL_NAME"); title_tmp.Add("EKSPORT");
                        title_tmp.Add("DESCRIPTION"); title_tmp.Add("LENGTH_PACK"); title_tmp.Add("WIDTH_PACK"); title_tmp.Add("HEIGHT_PACK"); title_tmp.Add("WEIGHT_V"); title_tmp.Add("WEIGHT");
                        title_tmp.Add("DELIVERY_PACKAGE_TYPE"); title_tmp.Add("DELIVERY_PACKAGE");
                    }

                    foreach (string[] it in sets.cfg.options)
                        if ((title_l[il] == "\"" + it[0] + "\"") || (title_l[il] == it[0]))
                        {
                            fine = true;
                            title_tmp.Add(it[1]);   // заголовок из наденных свойств
                            break;
                        }

                    if (!fine)
                    {
                        not_found_index.Add(il);
                        unload.Add(title_l[il]);      // не найденные свойства
                    }
                }

                foreach (string s in unload) save_uload += s + "\r\n";

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
                    if (i == shift)
                    {
                        /*title.Add("PROIZVODITEL"); */
                        title.Add("NAME"); title.Add("FULL_NAME"); title.Add("EKSPORT");
                        title.Add("DESCRIPTION"); title.Add("LENGTH_PACK"); title.Add("WIDTH_PACK"); title.Add("HEIGHT_PACK"); title.Add("WEIGHT_V"); title.Add("WEIGHT");
                        title.Add("DELIVERY_PACKAGE_TYPE"); title.Add("DELIVERY_PACKAGE");
                    }
                }
                // -------------------------------------------- Заголовок --------------------------------------------

                title = title.Distinct().ToList();
                foreach (string item in title_tmp)
                    normal_file.Append(item + ";");
                normal_file.Append("\r\n");  // файл с правильным заголовком

                Regex manual_get_line = new Regex("https(.*)", RegexOptions.Multiline);
                MatchCollection lines = get_line.Matches(fileText);
                StringBuilder str_bl = new StringBuilder();
                string buf;


                // ---------------------------------- Удаление символов новои строки ---------------------------------
                for (i = 1; i < lines.Count; i++)
                {
                    if (i == lines.Count - 1) { str_bl.Append(lines[i] + "\r\n"); break; }
                    if (manual_get_line.IsMatch(lines[i + 1].Value))
                        str_bl.Append(lines[i] + "\r\n");
                    else
                    {
                        buf = lines[i].Value;
                        buf = buf.Replace("\r\n", "");  buf = buf.Replace("\r", ""); buf = buf.Replace("\n", "");
                        buf += "__";
                        str_bl.Append(buf);
                    }
                }
                // ---------------------------------- Удаление символов новои строки ---------------------------------

                lines = get_line.Matches(str_bl.ToString());

                Regex r_celas = new Regex(";");
                string rn;
                foreach (Match line in lines)
                {
                    string[] cells = r_celas.Split(line.Value);
                    buf = "";
                    for (i = 0; i < cells.Length; i++)
                    {
                        if (i == shift) buf += ";;;;;;;;;;;";
                        if (sets.equal(i, not_found_index))     // - пропуск не наиденных столбцов
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
                    //MessageBox.Show("Не все поля заголовка были найденны.\r\nНедостающие свойства сохнаненны в файл unload.txt");
                }

                //File.WriteAllText("normal_file.csv", normal_file.ToString(), Encoding.Default);
                //MessageBox.Show("hi");
                List<Options> options_values = new List<Options>();
                StreamReader reader = new StreamReader(new MemoryStream(Encoding.GetEncoding(1251).GetBytes(normal_file.ToString())), Encoding.GetEncoding(1251));
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.Encoding = Encoding.GetEncoding(1251);
                    var info = new List<string>();
                    csv.Configuration.BadDataFound = data => {
                        info.Add(data.RawRecord);
                    };

                    var li = csv.GetRecords<Options>();
                    options_values = li.ToList();
                    options.AddRange(options_values);
                    options_values = null;
                }
            }

            foreach (var tl in title) sb.Append(tl + ";");
            sb.Remove(sb.Length - 1, 1);        //  удаление последнего разделительного символа
            sb.Append("\r\n");

            //                                  //  удаление кавычек
            foreach (Options option in options)
            {
                if (option.id == "2624611")
                {
                    //
                }
            }
            foreach (Options option in options) option.id = Regex.Replace(option.id, "\"", "");

            // --------------------------- добавление в список индексов ---------------------------
            Regex r_id = new Regex("(.*)\\/(\\d*)");
            foreach (Options option in options)
            {
                try
                {
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
            Get_xml xml_data = new Get_xml(xml, index);

            // --------------------------- формирование габаритов и веса --------------------------
            foreach (Options option in options)
                option.get_abc_weight(sets.cfg.coefficients_volume_and_mass, ref xml_data.get_xml_data);
            // --------------------------- формирование габаритов и веса --------------------------

            // --------------------------- выборка из массива классов свойств в string bufer для сохранения в текстовый файл --------------------------- 
            foreach (Options option in options)
            {
                Xml_offer time_xml_line = xml_data.get_xml_data.Find(data => data.id == option.artnumber);
                if (time_xml_line != null)
                {
                    option.proizvoditel = time_xml_line.vendor;
                }
                else { continue; }

                char[] se = { '_', '_' };
                // --------------------------- формироание описания ---------------------------
                string name = time_xml_line.name;
                string short_name = time_xml_line.name_short(time_xml_line.name, sets.cfg.prepositions, sets.cfg.stop_words);
                string proisvoditel = option.proizvoditel;
                string strana_prois = option.strana_proizvoditel;
                string price = Convert.ToString(time_xml_line.price * sets.get_coefficient(time_xml_line.price));
                string artnum = option.artnumber;
                //string material = option.material != "" ? option.material : time_xml_line.composition;
                string val = option.get_property("sostav", option);
                if (val != "")
                    option.sostav = val.Split(se)[0];
                string material = option.material != "" ? option.material : option.sostav;
                if (material == "")
                    material = time_xml_line.composition;
                string category = sets.get_name_of_category(time_xml_line.category);
                string product_color = option.product_color;
                string osob_cveta = option.osobennosti_cveta;

                object[] info = { name, short_name, proisvoditel, strana_prois, price, artnum, material, category, product_color, osob_cveta };

                option.description = classes.functions_stl.make_description(tmpl_description, info);

                // --------------------------- формироание описания ---------------------------
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

            options.Clear();

            List<Options_stl> options_last = new List<Options_stl>();
            List<Options_stl> options_new = new List<Options_stl>();
            string[] last_artnumbers, new_artnumbers, new_id, equal;
            string file_last_option = Directory.GetFiles(save).FirstOrDefault();

            if (file_last_option != null)
            {
                // ---------------------------------------------------- загрузка нового фаила с описанием -----------------------------------------------------
                using (var reader = new StringReader(sb.ToString()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.Encoding = Encoding.GetEncoding(1251);
                    var info = new List<string>();
                    csv.Configuration.BadDataFound = data =>
                    {
                        info.Add(data.RawRecord);
                    };

                    var li = csv.GetRecords<Options_stl>();
                    options_new = li.ToList();
                }
                // ---------------------------------------------------- загрузка нового фаила с описанием -----------------------------------------------------

                // -------------------------------------------------- загрузка предидущего фаила с описанием --------------------------------------------------
                using (var reader = new StreamReader(file_last_option, Encoding.GetEncoding(1251)))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.Encoding = Encoding.GetEncoding(1251);
                    var info = new List<string>();
                    csv.Configuration.BadDataFound = data =>
                    {
                        info.Add(data.RawRecord);
                    };

                    var li = csv.GetRecords<Options_stl>();
                    options_last = li.ToList();
                }
                // -------------------------------------------------- загрузка предидущего фаила с описанием --------------------------------------------------

                new_artnumbers = Options_stl.get_artbumbers(options_new);
                last_artnumbers = Options_stl.get_artbumbers(options_last);
                new_id = new_artnumbers.Except(last_artnumbers).ToArray();              //  нахождение новых позиции
                equal  = new_artnumbers.Intersect(last_artnumbers).ToArray();           //  нахождение совпадении

                //  добавление новых элементов
                Options_stl new_op = new Options_stl();
                foreach (string st in new_id)
                {
                    new_op = options_new.Find(l => l.artnumber == st);
                    options_last.Add(new_op);
                }

                // ------------------------------------------------------------ формирование фаила ------------------------------------------------------------
                // - заголовок
                sb.Clear();
                foreach (string item in title)
                    sb.Append(item + ";");
                sb.Remove(sb.Length - 1, 1);
                sb.Append("\r\n");
                // - заголовок

                string value;
                foreach (Options_stl op in options_last)
                {
                    foreach (string tl in title)
                    {
                        value = op.get_property(tl.ToLower(), op);
                        sb.Append(value + ";");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\r\n");
                }
                // ------------------------------------------------------------ формирование фаила ------------------------------------------------------------
            }
            // --------------------------- выборка из массива классов свойств в string bufer для созранения в текстовый файл --------------------------- 
            //сохраняем говый файл
            File.WriteAllText(save + "\\" + Path.GetFileNameWithoutExtension(xml) + ".csv", sb.ToString(), Encoding.GetEncoding(1251));

            // удаление файлов парсера
            foreach (string file_option in files_opions)
                File.Delete(file_option);
        }

        private void Form_stl_Load(object sender, EventArgs e)
        {
            //
        }
    }
}


public class cfg_data
{
    public List<string[]> options = new List<string[]>();                                                                               // список полей заголовка для замены на латиницу
    public List<string> prepositions = new List<string>();                                                                              // список предлогов для обрывки фразы
    public List<string> stop_words = new List<string>();                                                                                // список стоп слов для обрывки фразы
    public List<float[]> coefficients = new List<float[]>();                                                                            // список коэффициентов
    public List<string[]> categoryes = new List<string[]>();                                                                                   // список категорий
    public List<string[]> name_of_categoryes = new List<string[]>();                                                                           // список соотношений имени и кода категорий
                                                                                                                                        // Коэффициенты для габаритов и массы
    public List<coefficient_of_package>
        coefficients_volume_and_mass = new List<coefficient_of_package>();
    public struct coefficient_of_package
    {
        public int category_id; public float coefficient_of_massa; public float coefficient_of_dimensions;
    }
}
public partial class settings
{
    public cfg_data cfg = new cfg_data();
    public settings(/*string xml, */string options_folder, string save_folder, cfg_data cfg_up, string cfg_folder)
    {
        cfg.options = cfg_up.options;
        cfg.prepositions = cfg_up.prepositions;
        cfg.stop_words = cfg_up.stop_words;
        cfg.coefficients = cfg_up.coefficients;
        cfg.coefficients_volume_and_mass = cfg_up.coefficients_volume_and_mass;
        get_category(cfg_folder + "\\Соотнесение категорий.csv");
        get_name_of_category(cfg_folder + "\\id категории.csv");
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
            if (line[0] != "") cfg.categoryes.Add(cats);
        }
        cfg.categoryes.RemoveAt(0);
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
            if (line[0] != "") cfg.name_of_categoryes.Add(cats);
        }
        cfg.name_of_categoryes.RemoveAt(0);
    }

    public float get_coefficient(float price)
    {
        foreach (float[] range in cfg.coefficients)
            if ((price >= range[0]) && (price <= range[1]))
                return range[2];

        MessageBox.Show("Коэффициент не был найден");
        return 2;
    }

    public string get_name_of_category(int category_xml)
    {
        int category = 9;
        string category_Str = "";
        // категория обновленна, отличная от файла хмл, взятая из фаила соотнесение категории
        try { category = Convert.ToInt32(cfg.categoryes.Find(cat => Convert.ToInt32(cat[0]) == category_xml)[1]); }
        catch { return "{категория не найдена}"; }

        // назваие категории из фаила соотнесение категории соотнесенная по номеру
        try { category_Str = cfg.name_of_categoryes.Find(cat => Convert.ToInt32(cat[0]) == category)[1]; }
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