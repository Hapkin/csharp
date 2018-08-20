using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class RekeningInfo
    {
        public RekeningInfo(Decimal saldo, String klantNaam)
        {
            saldoValue = saldo;
            klantNaamValue = klantNaam;
        }

        private Decimal saldoValue;
        private String klantNaamValue;
        public Decimal Saldo
        { get { return saldoValue; } }
        public String Klantnaam
        { get { return klantNaamValue; } }

    }
}
