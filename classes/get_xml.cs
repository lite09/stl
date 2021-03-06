﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

public class Get_xml
{
    StringReader file_xml_data;
    string url;
    IEnumerable<Xml_offer> ienum_xml = null;
    public List<Xml_offer> get_xml_data = new List<Xml_offer>();

    public Get_xml(string xml, List<int> index)
	{
        //file_xml_data = new StringReader(File.ReadAllText(xml));
        //xml = File.ReadAllText(xml);
        try {
            file_xml_data = new StringReader(File.ReadAllText(xml, Encoding.UTF8));

            int l = new StringBuilder(File.ReadAllText(xml, Encoding.UTF8)).Length;
            if (l < 900)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                url = get_url_in_file(xml);

                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                try
                {
                    file_xml_data = new StringReader(wc.DownloadString(url));
                }
                catch
                {
                    //richTextBox2.Invoke((MethodInvoker)(() => richTextBox2.Text += "Не удалось загрузить фаил " + url + "\r\n"));

                    return;
                }
            }
        }
        catch {}
        ienum_xml = offer(file_xml_data, index);
        get_xml_data = ienum_xml.ToList();
        //MessageBox.Show("end");
    }

    public static string get_url_in_file(string file_name)
    {
        string url = null;
        try { url = File.ReadAllText(file_name); }
        catch { return null; }

        Regex get_url = new Regex("URL=(.*)\r\n");
        url = get_url.Match(url).Groups[1].Value;

        return url;
    }

    IEnumerable<Xml_offer> offer(StringReader string_xml, List <int> index)
    {

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Ignore;

        using (XmlReader reader = XmlReader.Create(string_xml, settings))
        {
            try { reader.MoveToContent(); }
            catch { MessageBox.Show("Не верный формат файла xml"); }

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "offer")
                        {
                            Xml_offer offer = new Xml_offer();
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            // float a, b, c;

                            IEnumerable<XElement> i;
                            offer.id = el.Attribute("id").Value;
                            bool find = false;
                            foreach (int id in index)
                            {
                                if (Convert.ToInt32(offer.id) != id) continue;
                                else { 
                                    index.RemoveAll(l => l == Convert.ToInt32(offer.id));
                                    find = true;
                                    break;
                                }
                            }

                            if (!find)
                                goto next_loop;

                            offer.name = el.Element("name").Value; offer.name = offer.name.Replace(";", " ");
                            offer.price = offer.price_time = Convert.ToSingle(el.Element("price").Value, CultureInfo.InvariantCulture);
                            try { offer.vendor = el.Element("vendor").Value; } catch { offer.vendor = ""; }
                            i = el.Elements("param").Where(e => (string)e.Attribute("name") == "Состав");
                            try { offer.composition = (string)i.FirstOrDefault(); } catch { offer.composition = ""; }
                            try { offer.category = Convert.ToInt32(el.Element("categoryId").Value); } catch { offer.category = 9999999; MessageBox.Show("нет категории"); }


                            if (el != null)
                                yield return offer;
                        }

                    break;
                }
            next_loop:;
            }
        }
    }
}

public class Xml_offer
{
    public int category;
    public string id, id_with_prefix;
    public float price, price_time;
    public string name, short_name, vendor, sales_notes, composition; // cостав

    // создание короткого имени
    public string name_short(string name, List<string> prepositions, List<string> stop_words)
    {
        //Regex short_name = new Regex(",");
        //string[] rx_short_name = short_name.Split(name);
        //return rx_short_name[0];

        //  до запятой -----------------------------------------------
        Regex short_name = new Regex("^([^,])*");
        Match rx_short_name = short_name.Match(name);
        name = rx_short_name.Groups[0].Value;
        // -----------------------------------------------------------

        //  предлоги -------------------------------------------------

        string preposition = null, time_name = null;
        foreach (string str in prepositions)
        {
            preposition = @"(.*)(\s+" + str + @"\s+)|\s*\S*|($)";
            //preposition = @"^(.*)(\s+с\s+)|\s*\S*|($)";
            short_name = new Regex(preposition);
            rx_short_name = short_name.Match(name);
            time_name = name;
            name = rx_short_name.Groups[1].Value;
            if (name == "") name = time_name;
        }
        // -----------------------------------------------------------

        //  цифры ----------------------------------------------------
        short_name = new Regex(@"^(\D*)((\s+\S*\d+)|($))");
        rx_short_name = short_name.Match(name);/*(\s)**/
        name = rx_short_name.Groups[1].Value;
        // -----------------------------------------------------------


        //  стоп слова -----------------------------------------------
        string stop_word_regex = null;
        foreach (string str in stop_words)
        {
            stop_word_regex = @"^(.*)" + str;
            //stop_word_regex = @"^(.*)(\s+с\s+)|.*|($)";
            short_name = new Regex(stop_word_regex);
            rx_short_name = short_name.Match(name);
            time_name = name;
            name = rx_short_name.Groups[1].Value;
            if (name == "") name = time_name;
        }
        // -----------------------------------------------------------

        //  обрезка пробелов в конце строки --------------------------
        short_name = new Regex(@"^(\D*[^\s*$])");
        rx_short_name = short_name.Match(name);
        name = rx_short_name.Groups[1].Value;
        // -----------------------------------------------------------

        while (name.Length > 60)
        {
            short_name = new Regex(@"^(.*)\s+\S+");
            rx_short_name = short_name.Match(name);
            name = rx_short_name.Groups[1].Value;
        }

        return name;
    }

    private static string utf_to_asci(string s, string[,] temls)
    {
        for (int i = 0; i < temls.Length / 2; i++)
            if(s!= null)
                s = s.Replace(temls[i, 0], temls[i, 1]);

        return s;
    }

    // Перевод строковых значений с UTF в ASCI формат
    public void to_asci(string[,] temls)
    {
        name = utf_to_asci(name, temls);
        short_name = utf_to_asci(short_name, temls);
        vendor = utf_to_asci(vendor, temls);
        sales_notes = utf_to_asci(sales_notes, temls);
        composition = utf_to_asci(composition, temls);
    }
}