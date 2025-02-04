using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public interface ICampanha
    {
        List<int> Produtos { get; set; }
        int CampanhaId { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        double Desconto { get; set; }
        DescontoType DescontoType { get; set; }
        public int AdicionarProduto(Hashtable ProductList, int product);
        public string MostrarDados(Hashtable ProductList);
    }
}
