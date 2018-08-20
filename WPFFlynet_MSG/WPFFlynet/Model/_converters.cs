using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
using WPFFlynet.Model.Message;
using System.Collections.ObjectModel;

namespace WPFFlynet.Model
{
    public class CheckboxConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //values[0] het certificaat van de checkbox
            //values[1] moet de lijst met ObservableCollection<Certificaat> zijn
            
            if (values[0] is Certificaat && values[1] is VliegendPersoneelslid)
            {
                //test function
                //ObservableCollection<Certificaat> works = new ObservableCollection<Certificaat>();
                //works.Add((Certificaat)values[0]);
                //

                var item = values[0];
                var collection = ((VliegendPersoneelslid)values[1]).Certificaten;
                return collection.Contains(item);
            }
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();

            
        }
    }
    class _converters
    {
    }
}
