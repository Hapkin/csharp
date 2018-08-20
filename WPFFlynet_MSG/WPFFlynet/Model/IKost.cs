using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlynet
{
    interface IKost
    {
        decimal BasisKostprijsPerDag { get; set; }
        decimal BerekenTotaleKostprijsPerDag();
    }
}
