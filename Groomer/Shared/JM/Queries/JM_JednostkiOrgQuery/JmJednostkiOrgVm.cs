using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Groomer.Shared.JM.Queries.JM_JednostkiOrgQuery
{
    public partial class JednostkiOrg
    {
        public string KON_ID_FIRMY { get; set; }
        public long? KON_NUMER { get; set; }
        public string JDO_SYMBOL_J { get; set; }
        public string? JDO_SYMBOL { get; set; }
        public string? JDO_SYMBOL_D { get; set; }
        public string JDO_NAZWA { get; set; }
        public string JDO_NAZWA_SKROT { get; set; }
        public string JDO_NAZWA_PELNA { get; set; }
        public string JDO_NAZWA_WYDLUZ { get; set; }
    }
    public  class JmJednostkiOrgVm
    {
        [JsonPropertyName("JEDNOSTKI_ORG")]
        public List<JednostkiOrg> JednostkiOrg { get; set; }
    }
}
