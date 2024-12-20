using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces
{
    public interface IVendedor
    {
        List<int> Products { get; set; }
        List<int> Marcas { get; set; }

        public Hashtable AddMarca(Hashtable MarcaList, int marcaid, string nome);
        public Hashtable AddStock(Hashtable ProductList, int productid, int quant);
    }
}
