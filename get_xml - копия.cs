using System;

public class get_xml
{
	public set_xml()
	{
	}

    IEnumerable<xml_offer> offer(StringReader string_xml)
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
            }
        }
    }
}


class xml_offer
{

    public string id, id_with_prefix;
    public int delivery_days, min_quantity;
    public float price, price_time, price_new, weight_new, a, b, c, a_new, b_new, c_new;

    public string available, categoryId, name, short_name, vendor, description, sales_notes,
        composition,                    // cостав
        product_color,
        size,
        gred,
        packing_size,
        //individual_packing,             // индивидуальная упаковка
        //certificate,
        weight,                         // вес
        in_stock,                       // на складе
        type_of_package,                // Тип упаковки, DELIVERY_PACKAGE_TYPE
        composition_of_package;         // Состав упаковки, DELIVERY_PACKAGE
    public List<string> pictures;

    public List<string> pictures_to_str(IEnumerable<XElement> pics)
    {
        List<string> pics_st = new List<string>();
        foreach (XElement el in pics) pics_st.Add((string)el);

        return pics_st;
    }


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
        foreach (string str in Form1.prepositions)
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
        foreach (string str in Form1.stop_words)
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