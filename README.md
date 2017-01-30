# DynamicsCrmOptionSetRetriever
Helper class to retrieve Dynamics CRM Option Set values from external string.

This a really simple class however it will reduce a lot of lines of code if you are doing integration from exterenal systems to CRM. The idea is to define all the mapping of external string to Option Set values in a application configuration key so less code will be required to translate from the external string to the crm optionset value.

If you have lines of code like the ones below this class will help you alot.
Another benefit is that the external string can be changed without affect the code.

```
public static OptionSet (string payment_method_string) {
    if (payment_method_string == 'cash') {
        return new OptionSet(123456);
    } else if (payment_method_string == 'credit_card') {
        return new OptionSet(123457);
    } else if (payment_method_string == 'debit_card') {
        return new OptionSet(123458);
    } else if (payment_method_string == 'paypal') {
        return new OptionSet(123459);
    } else if (payment_method_string == 'other') {
        return new OptionSet(123450);
    } else {
		throw new Exception("Invalid payment method string: " + payment_method_string);
	}
}
```

All this function code would be replaced by:
```
CrmOptionSetRetriever.GetOptionFromExternalString("order", "payment_method", payment_method_string);
```

The application configuration file (app.config or web.config) would be like the one below.

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key='OPTIONSET_SETTINGS' 
         value='
              [
                {
                  "entities": [
                    {
                      "name": "order",
                      "optionsets": [
                        {
                          "name": "payment_method",
                          "mapping": [
                            {
                              "external_string": "cash",
                              "crm_value": 123456
                            },
                            {
                              "external_string": "credit_card",
                              "crm_value": 123457
                            },
                            {
                              "external_string": "debit_card",
                              "crm_value": 123458
                            },
                            {
                              "external_string": "paypal",
                              "crm_value": 123459
                            },
                            {
                              "external_string": "other",
                              "crm_value": 123450
                            }
                          ]
                        },
...
                      ]
                    },
                    {
                      "name": "account",
                      "optionsets": [
                        {
                          "name": "optionset1",
                          "mapping": [
                            {
                              "external_string": "string5",
                              "crm_value": 5
                            },
                            {
                              "external_string": "string6",
                              "crm_value": 6
                            },
                            {
                              "external_string": "string7",
                              "crm_value": 7
                            },
                            {
                              "external_string": "string8",
                              "crm_value": 8
                            }
                          ]
                        }
                      ]
                    }
                  ]
                }
              ]' />
  </appSettings>
</configuration>
```
