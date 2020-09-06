


using CsvHelper.Configuration;
using System.Collections.Generic;

public class Options
{
    //[CsvHelper.Configuration.Attributes.Name("seriya")]
    public string SERIYA { get; set; }

    //[CsvHelper.Configuration.Attributes.Name("id")]
    public string ID{ get; set; }

    //[CsvHelper.Configuration.Attributes.Name("vid_podhvata_dlya_shtor")]
    public string VID_PODHVATA_DLYA_SHTOR { get; set; }
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