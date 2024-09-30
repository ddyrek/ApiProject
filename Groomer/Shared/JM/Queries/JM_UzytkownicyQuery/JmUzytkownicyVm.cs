using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Groomer.Shared.JM.Queries.JM_UzytkownicyQuery
{
    public partial class JmUzytkownicy
    {
        //[JsonPropertyName("UZY_UNID")]
        //public string? UzyUnid { get; set; }

        //[JsonPropertyName("UZY_LOGIN")]
        //public string? UzyLogin { get; set; }

        public string UZY_UNID { get; set; }
        public string UZY_LOGIN { get; set; }
        public object UZY_HASLO { get; set; }
        public string UZY_NAZWA { get; set; }
        public string UZY_LOTUS { get; set; }
        public string UZY_MAIL_LN { get; set; }
        public string UPR_GRUPA { get; set; }
        public string WGR_GRUPA { get; set; }
        public long? WWW_WERSJA { get; set; }
        public long? UZY_SERWIS { get; set; }
        public long? UZY_NR_RCP { get; set; }
        public object WYD_SYMBOL { get; set; }
        public object UZY_BRAMKI { get; set; }
        public long? UZY_ARCHIWALNY { get; set; }
        public string UZY_PROGNOZY { get; set; }
        public object MST_KOD { get; set; }
        public long? UZY_LOG_CZYTNIK { get; set; }
        public string UZY_KONSTR_WYR { get; set; }
        public object UZY_CZASY_OP_WYR { get; set; }
        public object UZY_OPERATOR_LIT { get; set; }
        public object UZY_TELEFON { get; set; }
        public List<long> UZY_JO_HANDEL { get; set; }
        public long? UZY_HANDEL { get; set; }
        public string UZY_JO_KONSTR { get; set; }
        public object UZY_PESEL { get; set; }
        public object UZY_HASLO_TEMP { get; set; }
        public long? UZY_OLD_NR_RCP { get; set; }
        public object UZY_OLD_LOGIN { get; set; }
        public long? UZY_AW_EXPERT { get; set; }
        public long? UZY_TLUMACZ { get; set; }
        public object UZY_JEZYKI_TLUM { get; set; }
        public long? UZY_EDI_LEROY { get; set; }
        public object USER_ID { get; set; }
        public object KOD_SKID { get; set; }
        public long? UZY_BLEDY_WER_HANDL { get; set; }
        public object UZY_TIMEZONE { get; set; }
        public object UZY_LANGUAGE { get; set; }
        public long? UZY_KONSTRUKTOR { get; set; }
        public long? UZY_MAIL_PBS_WERSJA { get; set; }
        public object TYP_WYROBU_SKRZYDLA_ID { get; set; }
        public object WERSJA_SKRZYDLA_ID { get; set; }
        public object KON_KOD_SKID { get; set; }
        public string TRADER_CONFIG { get; set; }
        public long? UZY_PRODUKCJA { get; set; }
        public long? ID { get; set; }
        public long? UZY_BEZ_SELLY { get; set; }
    }

    public partial class JmUzytkownicyVm
    {
        [JsonPropertyName("JM_UZYTKOWNICY")]
        public List<JmUzytkownicy> JmUzytkownicy { get; set; }
    }

}
