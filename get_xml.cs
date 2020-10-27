using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

public class Get_xml
{
    StringReader file_xml_data;
    IEnumerable<xml_offer> ienum_xml = null;
    List<xml_offer> get_xml_data = new List<xml_offer>();

    public Get_xml(string xml, List<int> index)
	{
        file_xml_data = new StringReader(File.ReadAllText(xml));
        ienum_xml = offer(file_xml_data, index);
        get_xml_data = ienum_xml.ToList();
    }

    IEnumerable<xml_offer> offer(StringReader string_xml, List <int> index)
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
                            xml_offer offer = new xml_offer();
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            // float a, b, c;

                            IEnumerable<XElement> i;
                            offer.id = offer.id_with_prefix = el.Attribute("id").Value;
                            foreach (int id in index)
                            {
                                if (Convert.ToInt32(offer.id) != id) continue;
                                else if (Convert.ToInt32(offer.id) == id) index.RemoveAll(l => l == Convert.ToInt32(offer.id));
                                else goto next_loop;
                            }

                            offer.name = el.Element("name").Value; offer.name = offer.name.Replace(";", " ");
                            offer.price = offer.price_time = Convert.ToSingle(el.Element("price").Value, CultureInfo.InvariantCulture);
                            try { offer.vendor = el.Element("vendor").Value; } catch { offer.vendor = ""; }
                            i = el.Elements("param").Where(e => (string)e.Attribute("name") == "Состав");
                            offer.composition = (string)i.FirstOrDefault();




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


class xml_offer
{
    List<string> prepositions = new List<string> {
        "A"/*латиница*/, "А"
    };

    List<string> stop_words = new List<string>
    {
        "d\\s*=", "h\\s*=", "r\\s*=", "А\\.", "№", "SchE",
        "ш\\."
    };

    public string id, id_with_prefix;
    public float price, price_time;

    public string name, short_name, vendor, sales_notes, composition; // cостав

    // создание короткого имени
    public string name_short(string name)
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

}