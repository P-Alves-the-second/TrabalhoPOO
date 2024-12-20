using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface ICliente
    {
        List<int> Compras { get; set; }
        public int Buy(Hashtable ProductList, Hashtable VendedorList, Hashtable CampanhaList, int productid);
    }
}
