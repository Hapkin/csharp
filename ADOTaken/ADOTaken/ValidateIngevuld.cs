using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using DBConnectie;

namespace ADOTaken
{
    public class ValidateKleur : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string textInput = "";

            textInput = (string)value;

            if (textInput == "")
                return new ValidationResult(false,
                    "Veld moet ingevuld zijn.");
            else
                return ValidationResult.ValidResult;
        }

    }
    public class ValidatePrijs : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal textInput = 0;

            if (!decimal.TryParse(value.ToString(), NumberStyles.Currency, cultureInfo, out textInput))
                return new ValidationResult(false, "Getal moet ingevuld zijn.");
            else
                return ValidationResult.ValidResult;
        }
    }
}
