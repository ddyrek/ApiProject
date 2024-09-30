using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Groomer.Shared.JM.Queries.JM_ZamowieniaWQuery
{
    public partial class JmZamowieniaW
    {
        public long? WWL_LP { get; set; }
        public string WWL_NAZWA { get; set; }
        public string WWW_TXT { get; set; }
        public long? WWW_INT { get; set; }
        public double? WWW_DEC { get; set; }
        public string ZAW_UNID { get; set; }
        public string? ZAN_NUMER { get; set; } //Varchar30
        public long? ZAS_LP { get; set; }
        public string? WYR_KTM { get; set; } //Varchar10
        public string? WYR_WERSJA { get; set; } //Varchar10
        public long? WWL_WIDOCZNA { get; set; }
        public long? WWL_TYP { get; set; }
        public long? WWL_ZAKRES { get; set; }
        public long? WWL_WYLICZANA { get; set; }
        public string WWL_WZOR { get; set; }
        public long? WWL_ZAOKRAGLENIE { get; set; }
        public string WWL_NAZWA_1 { get; set; }
        public long? WWL_TYP_1 { get; set; }
        public long? WWL_ZAKRES_1 { get; set; }
        public string WWL_NAZWA_2 { get; set; }
        public long? WWL_TYP_2 { get; set; }
        public long? WWL_ZAKRES_2 { get; set; }
        public string WWL_NAZWA_3 { get; set; }
        public long? WWL_TYP_3 { get; set; }
        public long? WWL_ZAKRES_3 { get; set; }
        public string WWL_NAZWA_4 { get; set; }
        public long? WWL_TYP_4 { get; set; }
        public long? WWL_ZAKRES_4 { get; set; }
        public string WWL_NAZWA_5 { get; set; }
        public long? WWL_TYP_5 { get; set; }
        public long? WWL_ZAKRES_5 { get; set; }
        public long? WWL_WYPELNIA { get; set; }
        public long? WWL_HURTOWNIK { get; set; }
        public long? WWL_INNE_WART { get; set; }
        public long? WWL_Z_POLKI { get; set; }
        public long? WWL_LP_PP { get; set; }
        public string WWL_KRYT_LOTUS { get; set; }
        public object WWW_WERSJA { get; set; }
        public object WWW_NIETYPOWA { get; set; }
        public string WWW_LOTUS { get; set; }
        public string ZMI_SYMBOL { get; set; }
        public long? WWL_WERSJA_HAND { get; set; }
        public long? WWL_ZMIANY_DO_HUR { get; set; }
        public long? WWW_NEGACJA_1 { get; set; }
        public long? WWW_NEGACJA_2 { get; set; }
        public long? WWW_NEGACJA_3 { get; set; }
        public long? WWW_NEGACJA_4 { get; set; }
        public long? WWW_NEGACJA_5 { get; set; }
        public object WWT_UNID { get; set; }
        public long? WWL_DRUKUJ_ZAWSZE { get; set; }
        public object WARTOSC { get; set; }
        public long? ID { get; set; }
        public long? ID_ZAM_S { get; set; }
        public long? CZY_APLIKACJA_ZEWN { get; set; }
        public Uri URL_APLIKACJI { get; set; }
    }

    public partial class JmZamowieniaWVm
    {
        [JsonPropertyName("JM_ZAMOWIENIA_W")]
        public List<JmZamowieniaW> JmZamowieniaW { get; set; }
    }
}
