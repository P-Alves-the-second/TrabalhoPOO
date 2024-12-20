using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums_DLL;

namespace Interfaces
{
    public interface IProduto
    {
        int VendedorId { get; set; }
        int ProductId { get; set; }
        int CampanhaId { get; set; }
        int MarcaId { get; set; }
        double Price { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        int Stock { get; set; }
        int Garantia { get; set; }
        DateTime DataCompra { get; set; }
        CategoriaProduto Categoria { get; set; }
        GarantiaType GarantiaType { get; set; }
        public int ChecarGarantia();
        public void Save();
        public void MostrarDados(Hashtable MarcaList) { }
    }
}
