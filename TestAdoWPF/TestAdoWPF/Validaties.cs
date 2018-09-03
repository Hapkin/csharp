using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestAdoWPF
{
    class Validaties
    {
    }



    public class IngevuldGroterDanNul : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            decimal getal;
            //NumberStyles style = NumberStyles.Currency;

            //mag niet ingevuld zijn?
            if (value == null || value.ToString() == string.Empty)
            {
                return ValidationResult.ValidResult;
            }
            if (!decimal.TryParse(value.ToString(), NumberStyles.Currency, cultureInfo, out getal))
            {
                return new ValidationResult(false, "Waarde moet een getal zijn");
            }
            if (getal <= 0)
            {
                return new ValidationResult(false, "Getal moet groter zijn dan nul");
            }
            return ValidationResult.ValidResult;
        }
    }


    public class ValidateIngevuld : ValidationRule
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


}
