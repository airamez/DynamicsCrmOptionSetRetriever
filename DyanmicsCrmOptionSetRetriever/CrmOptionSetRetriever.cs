using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Configuration;

namespace DyanmicsCrmOptionSetRetriever
{
    public static class CrmOptionSetRetriever
    {
        private static string OPTIONSET_SETTINGS = "OPTIONSET_SETTINGS";

        private static List<OptionSetSettings> _settings;

        static CrmOptionSetRetriever ()
        {
            Load();
        }

        private static void Load()
        {
            try
            {
                string settings = ConfigurationManager.AppSettings[OPTIONSET_SETTINGS];
                if (string.IsNullOrWhiteSpace(settings))
                {
                    throw new Exception("The rerquired configuration ket wasn't found: " + OPTIONSET_SETTINGS);
                }
                _settings = JsonConvert.DeserializeObject<List<OptionSetSettings>>(settings);
            }
            catch (Exception ex)
            {
                string msg = "Error loading the configuration. Please chek the '{0}' key on your confifuration file";
                throw new Exception(string.Format(msg, OPTIONSET_SETTINGS), ex);
            }
        }

        public static Microsoft.Xrm.Sdk.OptionSetValue GetOptionFromExternalString(string entityName, string optionsetName, string externalString)
        {
            var settings = _settings.FirstOrDefault();
            Entity entitySettings = settings.entities.FirstOrDefault(e => string.Compare(e.name, entityName, true) == 0);
            if (entitySettings == null)
            {
                throw new Exception(string.Format("Entity name '{0}' not found in '{1}' configuration key", entityName, OPTIONSET_SETTINGS));
            }
            Optionset optionset = entitySettings.optionsets.FirstOrDefault<Optionset>(o => string.Compare(o.name, optionsetName, true) == 0);
            if (optionset == null)
            {
                throw new Exception(string.Format("OptionSet name '{0}' not found in '{1}' configuration key", entityName, OPTIONSET_SETTINGS));
            }

            Mapping optionSetCrmValue = optionset.mapping.FirstOrDefault(m => string.Compare(m.external_string, externalString, true) == 0 );
            if (optionSetCrmValue == null)
            {
                throw new Exception(string.Format("External String with value '{0}' not found in '{1}' configuration key", entityName, OPTIONSET_SETTINGS));
            }
            return new Microsoft.Xrm.Sdk.OptionSetValue(optionSetCrmValue.crm_value);
        }
    }
}
