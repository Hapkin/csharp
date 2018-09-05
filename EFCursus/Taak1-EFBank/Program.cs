using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak1_EFBank
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var entities = new EFOpleidingenEntities()) { foreach (var docent in entities.Docenten) { Console.WriteLine(docent.Naam); } }


            Console.ReadLine();
        }
    }
}
