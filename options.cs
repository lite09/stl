using System;
using System.Reflection;

public class Options
{

    public string proizvoditel = "";
    public string description = "l";

    public string max_oboroty_ob_min;
    public string MAX_OBOROTY_OB_MIN{ get { return max_oboroty_ob_min; } set { max_oboroty_ob_min = value; } }
    public string author;
    public string AUTHOR{ get { return author; } set { author = value; } }
    public string adresat;
    public string ADRESAT{ get { return adresat; } set { adresat = value; } }
    public string aromatizirovannyye;
    public string AROMATIZIROVANNYYE{ get { return aromatizirovannyye; } set { aromatizirovannyye = value; } }
    public string artnumber;
    public string ARTNUMBER{ get { return artnumber; } set { artnumber = value; } }
    public string bokovye_stenki;
    public string BOKOVYE_STENKI{ get { return bokovye_stenki; } set { bokovye_stenki = value; } }
    public string v_komplekte;
    public string V_KOMPLEKTE{ get { return v_komplekte; } set { v_komplekte = value; } }
    public string v_nabore_sht;
    public string V_NABORE_SHT{ get { return v_nabore_sht; } set { v_nabore_sht = value; } }
    public string v_razobrannom_vide;
    public string V_RAZOBRANNOM_VIDE{ get { return v_razobrannom_vide; } set { v_razobrannom_vide = value; } }
    public string v_upakovke_sht;
    public string V_UPAKOVKE_SHT{ get { return v_upakovke_sht; } set { v_upakovke_sht = value; } }
    public string weight_v;
    public string WEIGHT_V{ get { return weight_v; } set { weight_v = value; } }
    public string ves_g_obem_ml;
    public string VES_G_OBEM_ML{ get { return ves_g_obem_ml; } set { ves_g_obem_ml = value; } }
    public string weight_kg;
    public string WEIGHT_KG{ get { return weight_kg; } set { weight_kg = value; } }
    public string ves_kg_obem_l;
    public string VES_KG_OBEM_L{ get { return ves_kg_obem_l; } set { ves_kg_obem_l = value; } }
    public string vid;
    public string VID{ get { return vid; } set { vid = value; } }
    public string vid_banta;
    public string VID_BANTA{ get { return vid_banta; } set { vid_banta = value; } }
    public string vid_bulavki;
    public string VID_BULAVKI{ get { return vid_bulavki; } set { vid_bulavki = value; } }
    public string vid_vazy;
    public string VID_VAZY{ get { return vid_vazy; } set { vid_vazy = value; } }
    public string vid_veshalki;
    public string VID_VESHALKI{ get { return vid_veshalki; } set { vid_veshalki = value; } }
    public string vid_golovolomki;
    public string VID_GOLOVOLOMKI{ get { return vid_golovolomki; } set { vid_golovolomki = value; } }
    public string vid_gravyury;
    public string VID_GRAVYURY{ get { return vid_gravyury; } set { vid_gravyury = value; } }
    public string vid_dekora;
    public string VID_DEKORA{ get { return vid_dekora; } set { vid_dekora = value; } }

    public string vid_deleniya;
    public string VID_DELENIYA { get { return vid_deleniya; } set { vid_deleniya = value; } }

    public string vid_dereva;
    public string VID_DEREVA{ get { return vid_dereva; } set { vid_dereva = value; } }
    public string vid_dyrokola;
    public string VID_DYROKOLA{ get { return vid_dyrokola; } set { vid_dyrokola = value; } }
    public string vid_edy;
    public string VID_EDY{ get { return vid_edy; } set { vid_edy = value; } }
    public string vid_zhivopisi;
    public string VID_ZHIVOPISI{ get { return vid_zhivopisi; } set { vid_zhivopisi = value; } }
    public string vid_zagotovki;
    public string VID_ZAGOTOVKI{ get { return vid_zagotovki; } set { vid_zagotovki = value; } }
    public string vid_clasp;
    public string VID_CLASP{ get { return vid_clasp; } set { vid_clasp = value; } }
    public string vid_kashpo;
    public string VID_KASHPO{ get { return vid_kashpo; } set { vid_kashpo = value; } }
    public string vid_kisti;
    public string VID_KISTI{ get { return vid_kisti; } set { vid_kisti = value; } }
    public string vid_kleya;
    public string VID_KLEYA{ get { return vid_kleya; } set { vid_kleya = value; } }
    public string vid_klyuchnicy;
    public string VID_KLYUCHNICY{ get { return vid_klyuchnicy; } set { vid_klyuchnicy = value; } }
    public string vid_kolyaski;
    public string VID_KOLYASKI{ get { return vid_kolyaski; } set { vid_kolyaski = value; } }
    public string vid_krepezha;
    public string VID_KREPEZHA{ get { return vid_krepezha; } set { vid_krepezha = value; } }
    public string vid_kryuchka;
    public string VID_KRYUCHKA{ get { return vid_kryuchka; } set { vid_kryuchka = value; } }
    public string vid_linejki;
    public string VID_LINEJKI{ get { return vid_linejki; } set { vid_linejki = value; } }
    public string vid_miniatyury;
    public string VID_MINIATYURY{ get { return vid_miniatyury; } set { vid_miniatyury = value; } }
    public string vid_naklejki;
    public string VID_NAKLEJKI{ get { return vid_naklejki; } set { vid_naklejki = value; } }
    public string vid_namotki;
    public string VID_NAMOTKI{ get { return vid_namotki; } set { vid_namotki = value; } }
    public string vid_opytov;
    public string VID_OPYTOV{ get { return vid_opytov; } set { vid_opytov = value; } }
    public string vid_osnovy;
    public string VID_OSNOVY{ get { return vid_osnovy; } set { vid_osnovy = value; } }
    public string vid_otkrytki;
    public string VID_OTKRYTKI{ get { return vid_otkrytki; } set { vid_otkrytki = value; } }
    public string vid_paneli;
    public string VID_PANELI { get { return vid_paneli; } set { vid_paneli = value; } }
    public string vid_pasteli;
    public string VID_PASTELI{ get { return vid_pasteli; } set { vid_pasteli = value; } }
    public string vid_pasty;
    public string VID_PASTY{ get { return vid_pasty; } set { vid_pasty = value; } }
    public string vid_peska;
    public string VID_PESKA{ get { return vid_peska; } set { vid_peska = value; } }
    public string vid_plastikovoj_niti;
    public string VID_PLASTIKOVOJ_NITI{ get { return vid_plastikovoj_niti; } set { vid_plastikovoj_niti = value; } }
    public string vid_podhvata_dlya_shtor;
    public string VID_PODHVATA_DLYA_SHTOR{ get { return vid_podhvata_dlya_shtor; } set { vid_podhvata_dlya_shtor = value; } }
    public string vid_pryazhi;
    public string VID_PRYAZHI{ get { return vid_pryazhi; } set { vid_pryazhi = value; } }
    public string vid_pugovicy;
    public string VID_PUGOVICY{ get { return vid_pugovicy; } set { vid_pugovicy = value; } }
    public string vid_raboty;
    public string VID_RABOTY{ get { return vid_raboty; } set { vid_raboty = value; } }
    public string vid_raskraski;
    public string VID_RASKRASKI{ get { return vid_raskraski; } set { vid_raskraski = value; } }
    public string vid_regilina;
    public string VID_REGILINA{ get { return vid_regilina; } set { vid_regilina = value; } }
    public string vid_rospisi;
    public string VID_ROSPISI{ get { return vid_rospisi; } set { vid_rospisi = value; } }
    public string vid_ruchki;
    public string VID_RUCHKI{ get { return vid_ruchki; } set { vid_ruchki = value; } }
    public string vid_slepka;
    public string VID_SLEPKA{ get { return vid_slepka; } set { vid_slepka = value; } }
    public string vid_spic;
    public string VID_SPIC{ get { return vid_spic; } set { vid_spic = value; } }
    public string vid_sporta;
    public string VID_SPORTA{ get { return vid_sporta; } set { vid_sporta = value; } }
    public string vid_spreya;
    public string VID_SPREYA{ get { return vid_spreya; } set { vid_spreya = value; } }
    public string vid_straz;
    public string VID_STRAZ{ get { return vid_straz; } set { vid_straz = value; } }
    public string vid_ustanovki;
    public string VID_UPAKOVKI { get { return vid_upakovki; } set { vid_upakovki = value; } }
    public string vid_upakovki;
    public string VID_USTANOVKI { get { return vid_ustanovki; } set { vid_ustanovki = value; } }
    public string vid_ustrojstva;
    public string VID_USTROJSTVA{ get { return vid_ustrojstva; } set { vid_ustrojstva = value; } }
    public string vid_freski;
    public string VID_FRESKI{ get { return vid_freski; } set { vid_freski = value; } }
    public string vid_cvetov;
    public string VID_CVETOV{ get { return vid_cvetov; } set { vid_cvetov = value; } }
    public string vid_cepi;
    public string VID_CEPI{ get { return vid_cepi; } set { vid_cepi = value; } }
    public string vid_shara;
    public string VID_SHARA{ get { return vid_shara; } set { vid_shara = value; } }
    public string vid_shtornoj_furnitury;
    public string VID_SHTORNOJ_FURNITURY{ get { return vid_shtornoj_furnitury; } set { vid_shtornoj_furnitury = value; } }
    public string vid_etyudnika_molberta;
    public string VID_ETYUDNIKA_MOLBERTA{ get { return vid_etyudnika_molberta; } set { vid_etyudnika_molberta = value; } }
    public string vlagozashchita;
    public string VLAGOZASHCHITA{ get { return vlagozashchita; } set { vlagozashchita = value; } }
    public string vneshnij_diametr_mm;
    public string VNESHNIJ_DIAMETR_MM{ get { return vneshnij_diametr_mm; } set { vneshnij_diametr_mm = value; } }
    public string vnutrennij_diametr_mm;
    public string VNUTRENNIJ_DIAMETR_MM{ get { return vnutrennij_diametr_mm; } set { vnutrennij_diametr_mm = value; } }
    public string vnutrennij_diametr_sm;
    public string VNUTRENNIJ_DIAMETR_SM{ get { return vnutrennij_diametr_sm; } set { vnutrennij_diametr_sm = value; } }
    public string vodonepronicaemyj;
    public string VODONEPRONICAEMYJ{ get { return vodonepronicaemyj; } set { vodonepronicaemyj = value; } }
    public string vozrast;
    public string VOZRAST{ get { return vozrast; } set { vozrast = value; } }
    public string min_vozr;
    public string MIN_VOZR{ get { return min_vozr; } set { min_vozr = value; } }
    public string vstavka;
    public string VSTAVKA{ get { return vstavka; } set { vstavka = value; } }
    public string vybor_imeni;
    public string VYBOR_IMENI{ get { return vybor_imeni; } set { vybor_imeni = value; } }
    public string vysota_bolshej_korobki_sm;
    public string VYSOTA_BOLSHEJ_KOROBKI_SM{ get { return vysota_bolshej_korobki_sm; } set { vysota_bolshej_korobki_sm = value; } }
    public string vysota_derzhatelya_sm;
    public string VYSOTA_DERZHATELYA_SM{ get { return vysota_derzhatelya_sm; } set { vysota_derzhatelya_sm = value; } }
    public string vysota_podramnika_sm;
    public string VYSOTA_PODRAMNIKA_SM{ get { return vysota_podramnika_sm; } set { vysota_podramnika_sm = value; } }
    public string vysota_mm;
    public string VYSOTA_MM{ get { return vysota_mm; } set { vysota_mm = value; } }
    public string vysota_sm;
    public string VYSOTA_SM{ get { return vysota_sm; } set { vysota_sm = value; } }
    public string garantiya;
    public string GARANTIYA{ get { return garantiya; } set { garantiya = value; } }
    public string gibkij_val;
    public string GIBKIJ_VAL{ get { return gibkij_val; } set { gibkij_val = value; } }
    public string glubina_mm;
    public string GLUBINA_MM{ get { return glubina_mm; } set { glubina_mm = value; } }
    public string glubina_sm;
    public string GLUBINA_SM{ get { return glubina_sm; } set { glubina_sm = value; } }
    public string year;
    public string YEAR{ get { return year; } set { year = value; } }
    public string gofrirovannaya;
    public string GOFRIROVANNAYA{ get { return gofrirovannaya; } set { gofrirovannaya = value; } }
    public string data;
    public string DATA{ get { return data; } set { data = value; } }
    public string dvojnaya_igla;
    public string DVOJNAYA_IGLA{ get { return dvojnaya_igla; } set { dvojnaya_igla = value; } }
    public string dvustoronnij;
    public string DVUSTORONNIJ{ get { return dvustoronnij; } set { dvustoronnij = value; } }
    public string dekorativnye_elementy;
    public string DEKORATIVNYE_ELEMENTY{ get { return dekorativnye_elementy; } set { dekorativnye_elementy = value; } }
    public string deleniya__vnutri_shkatulki;
    public string DELENIYA__VNUTRI_SHKATULKI{ get { return deleniya__vnutri_shkatulki; } set { deleniya__vnutri_shkatulki = value; } }
    public string detskie;
    public string DETSKIE{ get { return detskie; } set { detskie = value; } }
    public string diametr_glaz_mm;
    public string DIAMETR_GLAZ_MM{ get { return diametr_glaz_mm; } set { diametr_glaz_mm = value; } }
    public string diametr_obektiva_mm;
    public string DIAMETR_OBEKTIVA_MM{ get { return diametr_obektiva_mm; } set { diametr_obektiva_mm = value; } }
    public string diametr_otverstij_mm;
    public string DIAMETR_OTVERSTIJ_MM{ get { return diametr_otverstij_mm; } set { diametr_otverstij_mm = value; } }
    public string diametr_pishushchego_uzla_mm;
    public string DIAMETR_PISHUSHCHEGO_UZLA_MM{ get { return diametr_pishushchego_uzla_mm; } set { diametr_pishushchego_uzla_mm = value; } }
    public string diametr_sopla_mm;
    public string DIAMETR_SOPLA_MM{ get { return diametr_sopla_mm; } set { diametr_sopla_mm = value; } }
    public string diametr_straz_mm;
    public string DIAMETR_STRAZ_MM{ get { return diametr_straz_mm; } set { diametr_straz_mm = value; } }
    public string diametr_shara_sm;
    public string DIAMETR_SHARA_SM{ get { return diametr_shara_sm; } set { diametr_shara_sm = value; } }
    public string diametr_dyujm;
    public string DIAMETR_DYUJM{ get { return diametr_dyujm; } set { diametr_dyujm = value; } }
    public string diametr_mm;
    public string DIAMETR_MM{ get { return diametr_mm; } set { diametr_mm = value; } }
    public string diametr_sm;
    public string DIAMETR_SM{ get { return diametr_sm; } set { diametr_sm = value; } }
    public string displej;
    public string DISPLEJ{ get { return displej; } set { displej = value; } }
    public string differencialnaya_podacha;
    public string DIFFERENCIALNAYA_PODACHA{ get { return differencialnaya_podacha; } set { differencialnaya_podacha = value; } }
    public string dlina_bolshej_korobki_sm;
    public string DLINA_BOLSHEJ_KOROBKI_SM{ get { return dlina_bolshej_korobki_sm; } set { dlina_bolshej_korobki_sm = value; } }
    public string dlina_volos_sm;
    public string DLINA_VOLOS_SM{ get { return dlina_volos_sm; } set { dlina_volos_sm = value; } }
    public string dlina_zvena_mm;
    public string DLINA_ZVENA_MM{ get { return dlina_zvena_mm; } set { dlina_zvena_mm = value; } }
    public string dlina_igly_sm;
    public string DLINA_IGLY_SM{ get { return dlina_igly_sm; } set { dlina_igly_sm = value; } }
    public string dlina_minutnoj_strelki_mm;
    public string DLINA_MINUTNOJ_STRELKI_MM{ get { return dlina_minutnoj_strelki_mm; } set { dlina_minutnoj_strelki_mm = value; } }
    public string dlina_plastika_m;
    public string DLINA_PLASTIKA_M{ get { return dlina_plastika_m; } set { dlina_plastika_m = value; } }
    public string dlina_rezby_mm;
    public string DLINA_REZBY_MM{ get { return dlina_rezby_mm; } set { dlina_rezby_mm = value; } }
    public string dlina_rulona_m;
    public string DLINA_RULONA_M{ get { return dlina_rulona_m; } set { dlina_rulona_m = value; } }
    public string dlina_sekundnoj_strelki_mm;
    public string DLINA_SEKUNDNOJ_STRELKI_MM{ get { return dlina_sekundnoj_strelki_mm; } set { dlina_sekundnoj_strelki_mm = value; } }
    public string dlina_skrepki;
    public string DLINA_SKREPKI{ get { return dlina_skrepki; } set { dlina_skrepki = value; } }
    public string dlina_sterzhnya_mm;
    public string DLINA_STERZHNYA_MM{ get { return dlina_sterzhnya_mm; } set { dlina_sterzhnya_mm = value; } }
    public string dlina_cepochki_m;
    public string DLINA_CEPOCHKI_M{ get { return dlina_cepochki_m; } set { dlina_cepochki_m = value; } }
    public string dlina_chasovoj_strelki_mm;
    public string DLINA_CHASOVOJ_STRELKI_MM{ get { return dlina_chasovoj_strelki_mm; } set { dlina_chasovoj_strelki_mm = value; } }
    public string dlina_shtoka_mm;
    public string DLINA_SHTOKA_MM{ get { return dlina_shtoka_mm; } set { dlina_shtoka_mm = value; } }
    public string dlina_m;
    public string DLINA_M{ get { return dlina_m; } set { dlina_m = value; } }
    public string dlina_mm;
    public string DLINA_MM{ get { return dlina_mm; } set { dlina_mm = value; } }
    public string dlina_sm;
    public string DLINA_SM{ get { return dlina_sm; } set { dlina_sm = value; } }
    public string dlya_detej_do_3_let;
    public string DLYA_DETEJ_DO_3_LET{ get { return dlya_detej_do_3_let; } set { dlya_detej_do_3_let = value; } }
    public string dlya_kogo;
    public string DLYA_KOGO{ get { return dlya_kogo; } set { dlya_kogo = value; } }
    public string dlya_kukol_rostom_sm;
    public string DLYA_KUKOL_ROSTOM_SM{ get { return dlya_kukol_rostom_sm; } set { dlya_kukol_rostom_sm = value; } }
    public string dlya_sozdaniya;
    public string DLYA_SOZDANIYA{ get { return dlya_sozdaniya; } set { dlya_sozdaniya = value; } }
    public string dlya_sozdaniya_i_dekorirovaniya;
    public string DLYA_SOZDANIYA_I_DEKORIROVANIYA{ get { return dlya_sozdaniya_i_dekorirovaniya; } set { dlya_sozdaniya_i_dekorirovaniya = value; } }
    public string dno;
    public string DNO{ get { return dno; } set { dno = value; } }
    public string function;
    public string FUNCTION{ get { return function; } set { function = value; } }
    public string zhanr_igry;
    public string ZHANR_IGRY{ get { return zhanr_igry; } set { zhanr_igry = value; } }
    public string zapchast_dlya_podramnika;
    public string ZAPCHAST_DLYA_PODRAMNIKA{ get { return zapchast_dlya_podramnika; } set { zapchast_dlya_podramnika = value; } }
    public string zvuk;
    public string ZVUK{ get { return zvuk; } set { zvuk = value; } }
    public string iz_naturalnogo_dereva;
    public string IZ_NATURALNOGO_DEREVA{ get { return iz_naturalnogo_dereva; } set { iz_naturalnogo_dereva = value; } }
    public string izognutaya_forma;
    public string IZOGNUTAYA_FORMA{ get { return izognutaya_forma; } set { izognutaya_forma = value; } }
    public string inerciya;
    public string INERCIYA{ get { return inerciya; } set { inerciya = value; } }
    public string karabin;
    public string KARABIN{ get { return karabin; } set { karabin = value; } }
    public string karkas;
    public string KARKAS{ get { return karkas; } set { karkas = value; } }
    public string kist;
    public string KIST{ get { return kist; } set { kist = value; } }
    public string kolesa_roliki;
    public string KOLESA_ROLIKI{ get { return kolesa_roliki; } set { kolesa_roliki = value; } }
    public string kolichestvo_batareek;
    public string KOLICHESTVO_BATAREEK{ get { return kolichestvo_batareek; } set { kolichestvo_batareek = value; } }
    public string kolichestvo_vlozhenij_v_nabore;
    public string KOLICHESTVO_VLOZHENIJ_V_NABORE{ get { return kolichestvo_vlozhenij_v_nabore; } set { kolichestvo_vlozhenij_v_nabore = value; } }
    public string kolichestvo_zamkov;
    public string KOLICHESTVO_ZAMKOV{ get { return kolichestvo_zamkov; } set { kolichestvo_zamkov = value; } }
    public string kolichestvo_igrokov;
    public string KOLICHESTVO_IGROKOV{ get { return kolichestvo_igrokov; } set { kolichestvo_igrokov = value; } }
    public string kolichestvo_kryuchkov;
    public string KOLICHESTVO_KRYUCHKOV{ get { return kolichestvo_kryuchkov; } set { kolichestvo_kryuchkov = value; } }
    public string kolichestvo_kukol;
    public string KOLICHESTVO_KUKOL{ get { return kolichestvo_kukol; } set { kolichestvo_kukol = value; } }
    public string kolichestvo_listov;
    public string KOLICHESTVO_LISTOV { get { return kolichestvo_listov; } set { kolichestvo_listov = value; } }
    public string kolichestvo_nitej;
    public string KOLICHESTVO_NITEJ { get { return kolichestvo_nitej; } set { kolichestvo_nitej = value; } }

    public string kolichestvo_otverstij;
    public string KOLICHESTVO_OTVERSTIJ { get { return kolichestvo_otverstij; } set { kolichestvo_otverstij = value; } }

    public string kolichestvo_otdelenij;
    public string KOLICHESTVO_OTDELENIJ { get { return kolichestvo_otdelenij; } set { kolichestvo_otdelenij = value; } }

    public string kolichestvo_probivaemyh_listov;
    public string KOLICHESTVO_PROBIVAEMYH_LISTOV { get { return kolichestvo_probivaemyh_listov; } set { kolichestvo_probivaemyh_listov = value; } }
    public string kolichestvo_rezhimov;
    public string KOLICHESTVO_REZHIMOV { get { return kolichestvo_rezhimov; } set { kolichestvo_rezhimov = value; } }
    public string kolichestvo_rozhkov;
    public string KOLICHESTVO_ROZHKOV { get { return kolichestvo_rozhkov; } set { kolichestvo_rozhkov = value; } }
    public string kolichestvo_sekcij;
    public string KOLICHESTVO_SEKCIJ { get { return kolichestvo_sekcij; } set { kolichestvo_sekcij = value; } }
    public string kolichestvo_stranic;
    public string KOLICHESTVO_STRANIC { get { return kolichestvo_stranic; } set { kolichestvo_stranic = value; } }
    public string kolichestvo_fotografij;
    public string KOLICHESTVO_FOTOGRAFIJ { get { return kolichestvo_fotografij; } set { kolichestvo_fotografij = value; } }
    public string kolichestvo_cvetov;
    public string KOLICHESTVO_CVETOV { get { return kolichestvo_cvetov; } set { kolichestvo_cvetov = value; } }
    public string kolichestvo_cvetov_v_nabore;
    public string KOLICHESTVO_CVETOV_V_NABORE { get { return kolichestvo_cvetov_v_nabore; } set { kolichestvo_cvetov_v_nabore = value; } }
    public string kolichestvo_cvetov_nitok_v_nabore;
    public string KOLICHESTVO_CVETOV_NITOK_V_NABORE { get { return kolichestvo_cvetov_nitok_v_nabore; } set { kolichestvo_cvetov_nitok_v_nabore = value; } }
    public string kolichestvo_shvejnyh_operacij;
    public string KOLICHESTVO_SHVEJNYH_OPERACIJ { get { return kolichestvo_shvejnyh_operacij; } set { kolichestvo_shvejnyh_operacij = value; } }
    public string kolichestvo_elementov;
    public string KOLICHESTVO_ELEMENTOV { get { return kolichestvo_elementov; } set { kolichestvo_elementov = value; } }
    public string kolichestvo_yarusov;
    public string KOLICHESTVO_YARUSOV { get { return kolichestvo_yarusov; } set { kolichestvo_yarusov = value; } }
    public string kollekciya;
    public string KOLLEKCIYA { get { return kollekciya; } set { kollekciya = value; } }
    public string kolpachok_u_flomastera;
    public string KOLPACHOK_U_FLOMASTERA { get { return kolpachok_u_flomastera; } set { kolpachok_u_flomastera = value; } }
    public string komplektaciya;
    public string KOMPLEKTACIYA { get { return komplektaciya; } set { komplektaciya = value; } }
    public string kontrol_natyazheniya_nitej;
    public string KONTROL_NATYAZHENIYA_NITEJ { get { return kontrol_natyazheniya_nitej; } set { kontrol_natyazheniya_nitej = value; } }
    public string koreshok_mm;
    public string KORESHOK_MM { get { return koreshok_mm; } set { koreshok_mm = value; } }
    public string koefficient_sborki;
    public string KOEFFICIENT_SBORKI { get { return koefficient_sborki; } set { koefficient_sborki = value; } }
    public string kreplenie;
    public string KREPLENIE { get { return kreplenie; } set { kreplenie = value; } }
    public string kryshka;
    public string KRYSHKA { get { return kryshka; } set { kryshka = value; } }
    public string linovka_bloka;
    public string LINOVKA_BLOKA { get { return linovka_bloka; } set { linovka_bloka = value; } }
    public string licenziya;
    public string LICENZIYA { get { return licenziya; } set { licenziya = value; } }
    public string magnit;
    public string MAGNIT { get { return magnit; } set { magnit = value; } }
    public string magnitnye;
    public string MAGNITNYE { get { return magnitnye; } set { magnitnye = value; } }
    public string maks_skorost_shitsya_ob_min;
    public string MAKS_SKOROST_SHITSYA_OB_MIN { get { return maks_skorost_shitsya_ob_min; } set { maks_skorost_shitsya_ob_min = value; } }
    public string maksimalnaya_dlina_stezhka_mm;
    public string MAKSIMALNAYA_DLINA_STEZHKA_MM { get { return maksimalnaya_dlina_stezhka_mm; } set { maksimalnaya_dlina_stezhka_mm = value; } }
    public string maksimalnaya_shirina_stezhka_mm;
    public string MAKSIMALNAYA_SHIRINA_STEZHKA_MM { get { return maksimalnaya_shirina_stezhka_mm; } set { maksimalnaya_shirina_stezhka_mm = value; } }
    public string maksimalnoe_uvelichenie_krat;
    public string MAKSIMALNOE_UVELICHENIE_KRAT { get { return maksimalnoe_uvelichenie_krat; } set { maksimalnoe_uvelichenie_krat = value; } }
    public string maksimalnoe_chislo_nitej;
    public string MAKSIMALNOE_CHISLO_NITEJ { get { return maksimalnoe_chislo_nitej; } set { maksimalnoe_chislo_nitej = value; } }
    public string material;
    public string MATERIAL { get { return material; } set { material = value; } }
    public string material_vorsa_kisti;
    public string MATERIAL_VORSA_KISTI { get { return material_vorsa_kisti; } set { material_vorsa_kisti = value; } }
    public string material_dlya_applikacii;
    public string MATERIAL_DLYA_APPLIKACII { get { return material_dlya_applikacii; } set { material_dlya_applikacii = value; } }
    public string material_zvenev;
    public string MATERIAL_ZVENEV { get { return material_zvenev; } set { material_zvenev = value; } }
    public string material_kanvy;
    public string MATERIAL_KANVY { get { return material_kanvy; } set { material_kanvy = value; } }
    public string material_karkasa;
    public string MATERIAL_KARKASA { get { return material_karkasa; } set { material_karkasa = value; } }
    public string material_korpusa;
    public string MATERIAL_KORPUSA { get { return material_korpusa; } set { material_korpusa = value; } }
    public string material_kryuchka;
    public string MATERIAL_KRYUCHKA { get { return material_kryuchka; } set { material_kryuchka = value; } }
    public string material_leski;
    public string MATERIAL_LESKI { get { return material_leski; } set { material_leski = value; } }
    public string material_listov;
    public string MATERIAL_LISTOV { get { return material_listov; } set { material_listov = value; } }
    public string material_oblozhki;
    public string MATERIAL_OBLOZHKI { get { return material_oblozhki; } set { material_oblozhki = value; } }
    public string material_osnovaniya;
    public string MATERIAL_OSNOVANIYA { get { return material_osnovaniya; } set { material_osnovaniya = value; } }
    public string material_osnovy;
    public string MATERIAL_OSNOVY { get { return material_osnovy; } set { material_osnovy = value; } }
    public string material_ruchki;
    public string MATERIAL_RUCHKI { get { return material_ruchki; } set { material_ruchki = value; } }
    public string material_setki;
    public string MATERIAL_SETKI { get { return material_setki; } set { material_setki = value; } }
    public string material_upakovki;
    public string MATERIAL_UPAKOVKI { get { return material_upakovki; } set { material_upakovki = value; } }
    public string mesto_dlya_podpisi_foto;
    public string MESTO_DLYA_PODPISI_FOTO { get { return mesto_dlya_podpisi_foto; } set { mesto_dlya_podpisi_foto = value; } }
    public string model_bag;
    public string MODEL_BAG { get { return model_bag; } set { model_bag = value; } }
    public string mozhno_myt_v_posudomoechnoj_mashine;
    public string MOZHNO_MYT_V_POSUDOMOECHNOJ_MASHINE { get { return mozhno_myt_v_posudomoechnoj_mashine; } set { mozhno_myt_v_posudomoechnoj_mashine = value; } }
    public string morozostojkost;
    public string MOROZOSTOJKOST { get { return morozostojkost; } set { morozostojkost = value; } }
    public string power;
    public string POWER { get { return power; } set { power = value; } }
    public string na_kleevoj_osnove;
    public string NA_KLEEVOJ_OSNOVE { get { return na_kleevoj_osnove; } set { na_kleevoj_osnove = value; } }
    public string nabor;
    public string NABOR { get { return nabor; } set { nabor = value; } }
    public string naduvka_shara;
    public string NADUVKA_SHARA { get { return naduvka_shara; } set { naduvka_shara = value; } }
    public string naznachenie;
    public string NAZNACHENIE { get { return naznachenie; } set { naznachenie = value; } }
    public string naznachenie_kleya;
    public string NAZNACHENIE_KLEYA { get { return naznachenie_kleya; } set { naznachenie_kleya = value; } }
    public string naznachenie_nozhnic;
    public string NAZNACHENIE_NOZHNIC { get { return naznachenie_nozhnic; } set { naznachenie_nozhnic = value; } }
    public string naznachenie_oblozhki;
    public string NAZNACHENIE_OBLOZHKI { get { return naznachenie_oblozhki; } set { naznachenie_oblozhki = value; } }
    public string nalichie_serdechnika;
    public string NALICHIE_SERDECHNIKA { get { return nalichie_serdechnika; } set { nalichie_serdechnika = value; } }
    public string nalichie_udara;
    public string NALICHIE_UDARA { get { return nalichie_udara; } set { nalichie_udara = value; } }
    public string namotka;
    public string NAMOTKA { get { return namotka; } set { namotka = value; } }
    public string nauchnaya_tema;
    public string NAUCHNAYA_TEMA { get { return nauchnaya_tema; } set { nauchnaya_tema = value; } }
    public string nomer;
    public string NOMER { get { return nomer; } set { nomer = value; } }
    public string nomer_kanvy;
    public string NOMER_KANVY { get { return nomer_kanvy; } set { nomer_kanvy = value; } }
    public string nomer_shara;
    public string NOMER_SHARA { get { return nomer_shara; } set { nomer_shara = value; } }
    public string oblast_prim;
    public string OBLAST_PRIM{ get { return oblast_prim; } set { oblast_prim = value; } }
    public string obem_l;
    public string OBEM_L { get { return obem_l; } set { obem_l = value; } }

    public string ogranichitelnaya_linejka;
    public string OGRANICHITELNAYA_LINEJKA { get { return ogranichitelnaya_linejka; } set { ogranichitelnaya_linejka = value; } }

    public string volume_ml;
    public string VOLUME_ML { get { return volume_ml; } set { volume_ml = value; } }
    public string overlok;
    public string OVERLOK { get { return overlok; } set { overlok = value; } }
    public string odnocvetnyj;
    public string ODNOCVETNYJ { get { return odnocvetnyj; } set { odnocvetnyj = value; } }
    public string opticheskaya_skhema;
    public string OPTICHESKAYA_SKHEMA { get { return opticheskaya_skhema; } set { opticheskaya_skhema = value; } }
    public string osnastka_v_komplekte;
    public string OSNASTKA_V_KOMPLEKTE { get { return osnastka_v_komplekte; } set { osnastka_v_komplekte = value; } }
    public string osnova_bumagi;
    public string OSNOVA_BUMAGI { get { return osnova_bumagi; } set { osnova_bumagi = value; } }
    public string osnova_dlya_kulona;
    public string OSNOVA_DLYA_KULONA { get { return osnova_dlya_kulona; } set { osnova_dlya_kulona = value; } }
    public string osnova_kleya;
    public string OSNOVA_KLEYA { get { return osnova_kleya; } set { osnova_kleya = value; } }
    public string features;
    public string FEATURES { get { return features; } set { features = value; } }
    public string osobennosti_gravyury;
    public string OSOBENNOSTI_GRAVYURY { get { return osobennosti_gravyury; } set { osobennosti_gravyury = value; } }
    public string osobennosti_zagotovki;
    public string OSOBENNOSTI_ZAGOTOVKI { get { return osobennosti_zagotovki; } set { osobennosti_zagotovki = value; } }
    public string osobennosti_izdeliya;
    public string OSOBENNOSTI_IZDELIYA { get { return osobennosti_izdeliya; } set { osobennosti_izdeliya = value; } }
    public string osobennosti_lovcov_snov;
    public string OSOBENNOSTI_LOVCOV_SNOV { get { return osobennosti_lovcov_snov; } set { osobennosti_lovcov_snov = value; } }
    public string osobennosti_rancev;
    public string OSOBENNOSTI_RANCEV { get { return osobennosti_rancev; } set { osobennosti_rancev = value; } }
    public string osobennosti_ruchek;
    public string OSOBENNOSTI_RUCHEK { get { return osobennosti_ruchek; } set { osobennosti_ruchek = value; } }
    public string osobennosti_cveta;
    public string OSOBENNOSTI_CVETA { get { return osobennosti_cveta; } set { osobennosti_cveta = value; } }
    public string osobennosti_shkatulki;
    public string OSOBENNOSTI_SHKATULKI { get { return osobennosti_shkatulki; } set { osobennosti_shkatulki = value; } }
    public string osobennost;
    public string OSOBENNOST { get { return osobennost; } set { osobennost = value; } }
    public string osobennost_igly;
    public string OSOBENNOST_IGLY { get { return osobennost_igly; } set { osobennost_igly = value; } }
    public string osobennost_karabina;
    public string OSOBENNOST_KARABINA { get { return osobennost_karabina; } set { osobennost_karabina = value; } }
    public string osobennost_krafta;
    public string OSOBENNOST_KRAFTA { get { return osobennost_krafta; } set { osobennost_krafta = value; } }
    public string osobennost_medalnicy;
    public string OSOBENNOST_MEDALNICY { get { return osobennost_medalnicy; } set { osobennost_medalnicy = value; } }
    public string osobennost_nozhnic;
    public string OSOBENNOST_NOZHNIC { get { return osobennost_nozhnic; } set { osobennost_nozhnic = value; } }
    public string otdelka;
    public string OTDELKA{ get { return otdelka; } set { otdelka = value; } }
    public string otdelka_lent;
    public string OTDELKA_LENT{ get { return otdelka_lent; } set { otdelka_lent = value; } }
    public string otdelka_paketa;
    public string OTDELKA_PAKETA { get { return otdelka_paketa; } set { otdelka_paketa = value; } }
    public string otklyuchenie_nozha;
    public string OTKLYUCHENIE_NOZHA { get { return otklyuchenie_nozha; } set { otklyuchenie_nozha = value; } }
    public string oformlenie;
    public string OFORMLENIE { get { return oformlenie; } set { oformlenie = value; } }
    public string pedal;
    public string PEDAL { get { return pedal; } set { pedal = value; } }
    public string pishchevoj_plastik;
    public string PISHCHEVOJ_PLASTIK { get { return pishchevoj_plastik; } set { pishchevoj_plastik = value; } }
    public string plotnost_g_m2;
    public string PLOTNOST_G_M2 { get { return plotnost_g_m2; } set { plotnost_g_m2 = value; } }
    public string plotnost_kg_m3;
    public string PLOTNOST_KG_M3 { get { return plotnost_kg_m3; } set { plotnost_kg_m3 = value; } }
    public string usb;
    public string USB{ get { return usb; } set { usb = value; } }
    public string podsvetka;
    public string PODSVETKA { get { return podsvetka; } set { podsvetka = value; } }
    public string pokrytie;
    public string POKRYTIE { get { return pokrytie; } set { pokrytie = value; } }
    public string pokrytie_skrepki;
    public string POKRYTIE_SKREPKI{ get { return pokrytie_skrepki; } set { pokrytie_skrepki = value; } }
    public string rabotaet_ot_batareek;
    public string RABOTAET_OT_BATAREEK { get { return rabotaet_ot_batareek; } set { rabotaet_ot_batareek = value; } }
    public string rabotaet_ot_seti;
    public string RABOTAET_OT_SETI { get { return rabotaet_ot_seti; } set { rabotaet_ot_seti = value; } }
    public string razvitie_navykov;
    public string RAZVITIE_NAVYKOV { get { return razvitie_navykov; } set { razvitie_navykov = value; } }
    public string razmer_zvenev;
    public string RAZMER_ZVENEV { get { return razmer_zvenev; } set { razmer_zvenev = value; } }
    public string razmer_penala;
    public string RAZMER_PENALA { get { return razmer_penala; } set { razmer_penala = value; } }
    public string razmer_ploshchadki_mm;
    public string RAZMER_PLOSHCHADKI_MM { get { return razmer_ploshchadki_mm; } set { razmer_ploshchadki_mm = value; } }
    public string razmer_pugovicy;
    public string RAZMER_PUGOVICY { get { return razmer_pugovicy; } set { razmer_pugovicy = value; } }
    public string razmer_ruchki_kisti;
    public string RAZMER_RUCHKI_KISTI { get { return razmer_ruchki_kisti; } set { razmer_ruchki_kisti = value; } }
    public string razmer_foto;
    public string RAZMER_FOTO { get { return razmer_foto; } set { razmer_foto = value; } }
    public string razmer_dyujm;
    public string RAZMER_DYUJM { get { return razmer_dyujm; } set { razmer_dyujm = value; } }
    public string razmer_m;
    public string RAZMER_M { get { return razmer_m; } set { razmer_m = value; } }
    public string size_mm;
    public string SIZE_MM { get { return size_mm; } set { size_mm = value; } }
    //public string size;
    //public string SIZE { get { return ; } set {  = value; } }
    public string razmeshchenie;
    public string RAZMESHCHENIE { get { return razmeshchenie; } set { razmeshchenie = value; } }
    public string rasstoyanie_mezhdu_iglami_mm;
    public string RASSTOYANIE_MEZHDU_IGLAMI_MM { get { return rasstoyanie_mezhdu_iglami_mm; } set { rasstoyanie_mezhdu_iglami_mm = value; } }
    public string rasshirenie;
    public string RASSHIRENIE { get { return rasshirenie; } set { rasshirenie = value; } }
    public string regulirovka_temperatury;
    public string REGULIROVKA_TEMPERATURY { get { return regulirovka_temperatury; } set { regulirovka_temperatury = value; } }
    public string picture;
    public string PICTURE { get { return picture; } set { picture = value; } }
    public string rod_vojsk;
    public string ROD_VOJSK { get { return rod_vojsk; } set { rod_vojsk = value; } }
    public string rospis;
    public string ROSPIS { get { return rospis; } set { rospis = value; } }
    public string dolls_vysota;
    public string DOLLS_VYSOTA { get { return dolls_vysota; } set { dolls_vysota = value; } }
    public string ruchnaya_rabota;
    public string RUCHNAYA_RABOTA { get { return ruchnaya_rabota; } set { ruchnaya_rabota = value; } }
    public string s_golografiej;
    public string S_GOLOGRAFIEJ { get { return s_golografiej; } set { s_golografiej = value; } }
    public string s_napolneniem;
    public string S_NAPOLNENIEM { get { return s_napolneniem; } set { s_napolneniem = value; } }
    public string s_pajetkami;
    public string S_PAJETKAMI { get { return s_pajetkami; } set { s_pajetkami = value; } }
    public string s_ruchkami;
    public string S_RUCHKAMI { get { return s_ruchkami; } set { s_ruchkami = value; } }
    public string s_ruchkoj;
    public string S_RUCHKOJ { get { return s_ruchkoj; } set { s_ruchkoj = value; } }
    public string svet;
    public string SVET { get { return svet; } set { svet = value; } }
    public string svetitsya;
    public string SVETITSYA { get { return svetitsya; } set { svetitsya = value; } }
    public string svetopronicaemost;
    public string SVETOPRONICAEMOST { get { return svetopronicaemost; } set { svetopronicaemost = value; } }
    public string svecha_v_komplekte;
    public string SVECHA_V_KOMPLEKTE { get { return svecha_v_komplekte; } set { svecha_v_komplekte = value; } }
    public string sezon;
    public string SEZON { get { return sezon; } set { sezon = value; } }
    public string seriya;                           public string SERIYA { get { return seriya; } set { seriya = value; } }
    public string sertifikat;
    public string SERTIFIKAT { get { return sertifikat; } set { sertifikat = value; } }
    public string simvol_goda;
    public string SIMVOL_GODA { get { return simvol_goda; } set { simvol_goda = value; } }
    public string skladnoj;
    public string SKLADNOJ { get { return skladnoj; } set { skladnoj = value; } }
    public string smena_sopla;
    public string SMENA_SOPLA { get { return smena_sopla; } set { smena_sopla = value; } }
    public string sostav;
    public string SOSTAV { get { return sostav; } set { sostav = value; } }
    public string sostav_nabora;
    public string SOSTAV_NABORA { get { return sostav_nabora; } set { sostav_nabora = value; } }
    public string sostav_tkani;
    public string SOSTAV_TKANI { get { return sostav_tkani; } set { sostav_tkani = value; } }
    public string sostav_tkani_holsta;
    public string SOSTAV_TKANI_HOLSTA { get { return sostav_tkani_holsta; } set { sostav_tkani_holsta = value; } }
    public string sostavlyayushchie_nabora;
    public string SOSTAVLYAYUSHCHIE_NABORA { get { return sostavlyayushchie_nabora; } set { sostavlyayushchie_nabora = value; } }
    public string spicy_n;
    public string SPICY_N { get { return spicy_n; } set { spicy_n = value; } }
    public string sposob_naneseniya_kleya;
    public string SPOSOB_NANESENIYA_KLEYA { get { return sposob_naneseniya_kleya; } set { sposob_naneseniya_kleya = value; } }
    public string sterzhen_zamenyaemyj;
    public string STERZHEN_ZAMENYAEMYJ { get { return sterzhen_zamenyaemyj; } set { sterzhen_zamenyaemyj = value; } }
    public string strana_proizvoditel;
    public string STRANA_PROIZVODITEL { get { return strana_proizvoditel; } set { strana_proizvoditel = value; } }
    public string tverdost;
    public string TVERDOST { get { return tverdost; } set { tverdost = value; } }
    public string tverdost_grifelya;
    public string TVERDOST_GRIFELYA { get { return tverdost_grifelya; } set { tverdost_grifelya = value; } }
    public string tema_obucheniya;
    public string TEMA_OBUCHENIYA { get { return tema_obucheniya; } set { tema_obucheniya = value; } }
    public string tematika;
    public string TEMATIKA { get { return tematika; } set { tematika = value; } }
    public string tematika_konstruktora;
    public string TEMATIKA_KONSTRUKTORA { get { return tematika_konstruktora; } set { tematika_konstruktora = value; } }
    public string tematika_moldov;
    public string TEMATIKA_MOLDOV { get { return tematika_moldov; } set { tematika_moldov = value; } }
    public string tematika_nabora;
    public string TEMATIKA_NABORA { get { return tematika_nabora; } set { tematika_nabora = value; } }
    public string tematika_prazdnika;
    public string TEMATIKA_PRAZDNIKA { get { return tematika_prazdnika; } set { tematika_prazdnika = value; } }
    public string tematika_risunka;
    public string TEMATIKA_RISUNKA { get { return tematika_risunka; } set { tematika_risunka = value; } }
    public string temperaturnyj_rezhim;
    public string TEMPERATURNYJ_REZHIM { get { return temperaturnyj_rezhim; } set { temperaturnyj_rezhim = value; } }
    public string tekhnika_vypolneniya;
    public string TEKHNIKA_VYPOLNENIYA { get { return tekhnika_vypolneniya; } set { tekhnika_vypolneniya = value; } }
    public string type;
    public string TYPE { get { return type; } set { type = value; } }
    public string tip_vykladki;
    public string TIP_VYKLADKI { get { return tip_vykladki; } set { tip_vykladki = value; } }
    public string tip_gipsovoj_figury;
    public string TIP_GIPSOVOJ_FIGURY { get { return tip_gipsovoj_figury; } set { tip_gipsovoj_figury = value; } }
    public string tip_grunta_holsta;
    public string TIP_GRUNTA_HOLSTA { get { return tip_grunta_holsta; } set { tip_grunta_holsta = value; } }
    public string tip_doski;
    public string TIP_DOSKI { get { return tip_doski; } set { tip_doski = value; } }
    public string tip_ezhednevnika;
    public string TIP_EZHEDNEVNIKA { get { return tip_ezhednevnika; } set { tip_ezhednevnika = value; } }
    public string type_clasp;
    public string TYPE_CLASP { get { return type_clasp; } set { type_clasp = value; } }
    public string tip_kleya;
    public string TIP_KLEYA { get { return tip_kleya; } set { tip_kleya = value; } }
    public string tip_kopilki;
    public string TIP_KOPILKI { get { return tip_kopilki; } set { tip_kopilki = value; } }
    public string tip_lista;
    public string TIP_LISTA { get { return tip_lista; } set { tip_lista = value; } }
    public string tip_modeli;
    public string TIP_MODELI { get { return tip_modeli; } set { tip_modeli = value; } }
    public string tip_nakonechnika;
    public string TIP_NAKONECHNIKA { get { return tip_nakonechnika; } set { tip_nakonechnika = value; } }
    public string tip_naneseniya_risunka;
    public string TIP_NANESENIYA_RISUNKA { get { return tip_naneseniya_risunka; } set { tip_naneseniya_risunka = value; } }
    public string tip_nozha;
    public string TIP_NOZHA { get { return tip_nozha; } set { tip_nozha = value; } }
    public string tip_oblozhki;
    public string TIP_OBLOZHKI { get { return tip_oblozhki; } set { tip_oblozhki = value; } }
    public string tip_osnovy;
    public string TIP_OSNOVY { get { return tip_osnovy; } set { tip_osnovy = value; } }
    public string tip_pitaniya;
    public string TIP_PITANIYA { get { return tip_pitaniya; } set { tip_pitaniya = value; } }
    public string tip_plansheta;
    public string TIP_PLANSHETA { get { return tip_plansheta; } set { tip_plansheta = value; } }
    public string tip_pyalec;
    public string TIP_PYALEC { get { return tip_pyalec; } set { tip_pyalec = value; } }
    public string tip_rasteniya;
    public string TIP_RASTENIYA { get { return tip_rasteniya; } set { tip_rasteniya = value; } }
    public string tip_skladok;
    public string TIP_SKLADOK { get { return tip_skladok; } set { tip_skladok = value; } }
    public string tip_skrepleniya;
    public string TIP_SKREPLENIYA { get { return tip_skrepleniya; } set { tip_skrepleniya = value; } }
    public string tip_termonakleek;
    public string TIP_TERMONAKLEEK { get { return tip_termonakleek; } set { tip_termonakleek = value; } }
    public string tip_holsta;
    public string TIP_HOLSTA { get { return tip_holsta; } set { tip_holsta = value; } }
    public string tiporazmer_batareek;
    public string TIPORAZMER_BATAREEK { get { return tiporazmer_batareek; } set { tiporazmer_batareek = value; } }
    public string tisnenie;
    public string TISNENIE { get { return tisnenie; } set { tisnenie = value; } }
    public string tkan;
    public string TKAN{ get { return tkan; } set { tkan = value; } }
    public string tolshchina_niti_mm;
    public string TOLSHCHINA_NITI_MM { get { return tolshchina_niti_mm; } set { tolshchina_niti_mm = value; } }
    public string tolshchina_mkm;
    public string TOLSHCHINA_MKM { get { return tolshchina_mkm; } set { tolshchina_mkm = value; } }
    public string tolshchina_mm;
    public string TOLSHCHINA_MM { get { return tolshchina_mm; } set { tolshchina_mm = value; } }
    public string torgovaya_marka;
    public string TORGOVAYA_MARKA { get { return torgovaya_marka; } set { torgovaya_marka = value; } }
    public string torcevoj_karman;
    public string TORCEVOJ_KARMAN { get { return torcevoj_karman; } set { torcevoj_karman = value; } }
    public string uvelichenie_krat;
    public string UVELICHENIE_KRAT { get { return uvelichenie_krat; } set { uvelichenie_krat = value; } }
    public string usloviya_hraneniya;
    public string USLOVIYA_HRANENIYA { get { return usloviya_hraneniya; } set { usloviya_hraneniya = value; } }
    public string utolshchennye;
    public string UTOLSHCHENNYE { get { return utolshchennye; } set { utolshchennye = value; } }
    public string faktura;
    public string FAKTURA { get { return faktura; } set { faktura = value; } }
    public string faktura_bumagi;
    public string FAKTURA_BUMAGI { get { return faktura_bumagi; } set { faktura_bumagi = value; } }
    public string fokusnoe_rasstoyanie_mm;
    public string FOKUSNOE_RASSTOYANIE_MM { get { return fokusnoe_rasstoyanie_mm; } set { fokusnoe_rasstoyanie_mm = value; } }
    public string forma;
    public string FORMA{ get { return forma; } set { forma = value; } }
    public string forma_akvariuma;
    public string FORMA_AKVARIUMA { get { return forma_akvariuma; } set { forma_akvariuma = value; } }
    public string forma_volos;
    public string FORMA_VOLOS { get { return forma_volos; } set { forma_volos = value; } }
    public string forma_glaz;
    public string FORMA_GLAZ { get { return forma_glaz; } set { forma_glaz = value; } }
    public string forma_igrushki;
    public string FORMA_IGRUSHKI { get { return forma_igrushki; } set { forma_igrushki = value; } }
    public string forma_kisti;
    public string FORMA_KISTI { get { return forma_kisti; } set { forma_kisti = value; } }
    public string forma_matreshki;
    public string FORMA_MATRESHKI { get { return forma_matreshki; } set { forma_matreshki = value; } }
    public string forma_mela;
    public string FORMA_MELA { get { return forma_mela; } set { forma_mela = value; } }
    public string forma_straz;
    public string FORMA_STRAZ { get { return forma_straz; } set { forma_straz = value; } }
    public string format;
    public string FORMAT { get { return format; } set { format = value; } }
    public string hod;
    public string HOD{ get { return hod; } set { hod = value; } }
    public string canga_mm;
    public string CANGA_MM { get { return canga_mm; } set { canga_mm = value; } }
    public string product_color;
    public string PRODUCT_COLOR { get { return product_color; } set { product_color = value; } }
    public string cvet_bageta;
    public string CVET_BAGETA { get { return cvet_bageta; } set { cvet_bageta = value; } }
    public string cvet_volos;
    public string CVET_VOLOS { get { return cvet_volos; } set { cvet_volos = value; } }
    public string cvet_zvenev;
    public string CVET_ZVENEV { get { return cvet_zvenev; } set { cvet_zvenev = value; } }
    public string cvet_korpusa;
    public string CVET_KORPUSA { get { return cvet_korpusa; } set { cvet_korpusa = value; } }
    public string cvet_mebeli;
    public string CVET_MEBELI { get { return cvet_mebeli; } set { cvet_mebeli = value; } }
    public string cvet_otdelki;
    public string CVET_OTDELKI { get { return cvet_otdelki; } set { cvet_otdelki = value; } }
    public string cvet_svecheniya;
    public string CVET_SVECHENIYA { get { return cvet_svecheniya; } set { cvet_svecheniya = value; } }
    public string cvet_sterzhnya;
    public string CVET_STERZHNYA { get { return cvet_sterzhnya; } set { cvet_sterzhnya = value; } }
    public string cvet_furnitury;
    public string CVET_FURNITURY { get { return cvet_furnitury; } set { cvet_furnitury = value; } }
    public string shirina_bolshej_korobki_sm;
    public string SHIRINA_BOLSHEJ_KOROBKI_SM { get { return shirina_bolshej_korobki_sm; } set { shirina_bolshej_korobki_sm = value; } }
    public string shirina_zvena_mm;
    public string SHIRINA_ZVENA_MM { get { return shirina_zvena_mm; } set { shirina_zvena_mm = value; } }
    public string shirina_lenty_sm;
    public string SHIRINA_LENTY_SM { get { return shirina_lenty_sm; } set { shirina_lenty_sm = value; } }
    public string shirina_niti_mm;
    public string SHIRINA_NITI_MM { get { return shirina_niti_mm; } set { shirina_niti_mm = value; } }
    public string width_mm;
    public string WIDTH_ММ { get { return width_mm; } set { width_mm = value; } }
    public string shirina_sm;
    public string SHIRINA_SM { get { return shirina_sm; } set { shirina_sm = value; } }
    public string shkolnyj_predmet;
    public string SHKOLNYJ_PREDMET { get { return shkolnyj_predmet; } set { shkolnyj_predmet = value; } }
    public string elektromontazhnyj_instrument;
    public string ELEKTROMONTAZHNYJ_INSTRUMENT { get { return elektromontazhnyj_instrument; } set { elektromontazhnyj_instrument = value; } }
    public string effekt;
    public string EFFEKT { get { return effekt; } set { effekt = value; } }
    public string effekty;
    public string EFFEKTY { get { return effekty; } set { effekty = value; } }
    public string id;                           public string ID { get { return id; } set { id = value; } }
    public string torg_predl;
    public string TORG_PREDL { get { return torg_predl; } set { torg_predl = value; } }
    public string in_box;
    public string IN_BOX { get { return in_box; } set { in_box = value; } }
    public string fassovka;
    public string FASSOVKA { get { return fassovka; } set { fassovka = value; } }
    public string indivi_upa;
    public string INDIVI_UPA { get { return indivi_upa; } set { indivi_upa = value; } }
    public string size_upa;
    public string SIZE_UPA { get { return size_upa; } set { size_upa = value; } }
    public string size;
    public string SIZE { get { return size; } set { size = value; } }
    public string ves_brutto;
    public string VES_BRUTTO { get { return ves_brutto; } set { ves_brutto = value; } }
    public string ves_netto_g;
    public string VES_NETTO_G { get { return ves_netto_g; } set { ves_netto_g = value; } }
    public string price_for_the_one;
    public string PRICE_FOR_THE_ONE { get { return price_for_the_one; } set { price_for_the_one = value; } }
    public string price_for;
    public string PRICE_FOR { get { return price_for; } set { price_for = value; } }
    public string europodves;
    public string EUROPODVES { get { return europodves; } set { europodves = value; } }
    public string shtrihcod;
    public string SHTRIHCOD { get { return shtrihcod; } set { shtrihcod = value; } }
    public string price_for_;
    public string PRICE_FOR_{ get { return price_for_; } set { price_for_ = value; } }

    public string get_property(string property, Options op)
    {
        if (property == "") {
        }
        try     {
            FieldInfo i = typeof(Options).GetField(property.ToLower());
            if (i == null)
                return "";

            object value = i.GetValue(op);//.ToString();
            if (value == null)
                return "";

            return value.ToString();
        }
        catch   { return ""; }
    }
}
