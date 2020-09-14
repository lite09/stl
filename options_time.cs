


using CsvHelper.Configuration;
using System.Collections.Generic;

public class Options
{
    //[CsvHelper.Configuration.Attributes.Name("seriya")]
    public string seriya;
    public string SERIYA
    {
        get { return seriya; }
        set { seriya = value; }
    }

    //[CsvHelper.Configuration.Attributes.Name("id")]
    public string id;
    public string ID {
        get { return id; }
        set { id = value; }
    }

    //[CsvHelper.Configuration.Attributes.Name("vid_podhvata_dlya_shtor")]
    public string vid_podhvata_dlya_shtor;
    public string VID_PODHVATA_DLYA_SHTOR
    {
        get { return vid_podhvata_dlya_shtor; }
        set { vid_podhvata_dlya_shtor = value; }
    }

    public string test = "";
}

public class Options_info
{
    Dictionary<string, string> l = new Dictionary<string, string>();
}

//public class map : ClassMap<Options>
//{
//    public map()
//    {
//        Map(m => m.ID).Name("id");
//        Map(m => m.SERIYA).Name("seriya");
//        Map(m => m.VID_PODHVATA_DLYA_SHTOR).Name("vid_podhvata_dlya_shtor");
//    }
//}