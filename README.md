# DynamicsCrmOptionSetRetriever
Helper class to retrieve Dynamics CRM Option Set values from external string.

This a really simple class however it will reduce a lot of lines of code if you are doing integration from exterenal systems to CRM. The idea is to define all the mapping of external string to Option Set values in a application configuration key so less code will be required to translate from the external string to the crm optionset value.

If you have lines of code like the ones below this class will help you alot.

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
    }
}
