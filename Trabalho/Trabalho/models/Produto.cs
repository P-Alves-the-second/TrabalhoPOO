using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    public class Produto 
    {
        private int vendedorid {  get; set; }
        private int productid {  get; set; }

        private int marcaid {  get; set; }
        private int price {  get; set; }
        private string nome { get; set; }
        private string descricao { get; set; }
        private int stock {  get; set; }
        private CategoriaProduto categoria {  get; set; }

        public int VendedorId 
        {
            get => vendedorid;
            set => vendedorid = value;
        }
        public int ProductId
        {
            get => productid;
            set => productid = value;
        }
        public int MarcaId 
        {
            get => marcaid;
            set => marcaid = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }

        public string Nome 
        {
            get => nome;
            set => nome = value;
        }

        public string Descricao 
        {
            get => descricao;
            set => descricao = value;
        }

        public int Stock 
        {
            get => stock;
            set => stock = value;
        }

        public CategoriaProduto Categoria 
        {
            get => categoria;
            set => categoria = value;
        }

        public Produto(int vendedorid, int productid,int marcaid, int price, string nome, string descricao, int stock, CategoriaProduto categoria)
        {
            this.vendedorid = vendedorid;
            this.productid = productid;
            this.marcaid = marcaid;
            this.price = price;
            this.nome = nome;
            this.descricao = descricao;
            this.stock = stock;
            this.categoria = categoria;
        }
    }
}
