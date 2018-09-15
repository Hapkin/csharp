using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak1_EFBank
{
    public partial class Rekeningen
    {


        public void Storten(decimal bedrag)
        {
            Saldo += bedrag; 
        }
    }
}
