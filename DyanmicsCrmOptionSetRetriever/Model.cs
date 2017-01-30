using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyanmicsCrmOptionSetRetriever
{
    public class OptionSetSettings
    {
        public List<Entity> entities { get; set; }
    }

    public class Entity
    {
        public string name { get; set; }
        public List<Optionset> optionsets { get; set; }
    }

    public class Optionset
    {
        public string name { get; set; }
        public List<Mapping> mapping { get; set; }
    }
    public class Mapping
    {
        public string external_string { get; set; }
        public int crm_value { get; set; }
    }
}
