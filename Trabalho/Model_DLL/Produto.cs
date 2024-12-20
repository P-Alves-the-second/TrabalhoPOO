using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums_DLL;

namespace Model_DLL
{
    public class Produto 
    {
        private int vendedorid {  get; set; }
        private int productid {  get; set; }
        private int campanhaid {  get; set; }
        private int marcaid {  get; set; }
        private double price {  get; set; }
        private string nome { get; set; }
        private string descricao { get; set; }
        private int stock {  get; set; }

        private int garantia { get; set; }

        private DateTime datacompra {  get; set; }
        private CategoriaProduto categoria {  get; set; }

        private GarantiaType garantiatype { get; set; }

        

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
        public double Price
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

        public DateTime DataCompra 
        {
            get => datacompra;
            set => datacompra = value;
        }

        public int Garantia 
        {
            get => garantia;
            set => garantia = value;
        }

        public GarantiaType GarantiaType 
        {
            get => garantiatype;
            set => garantiatype = value;
        }
        public int CampanhaId
        {
            get => campanhaid;
            set => campanhaid = value;
        }

        public Produto(int vendedorid, int productid,int marcaid, double price, string nome, string descricao, int stock, CategoriaProduto categoria, int garantia ,GarantiaType garantiaType)
        {
            this.vendedorid = vendedorid;
            this.productid = productid;
            this.marcaid = marcaid;
            this.price = price;
            this.nome = nome;
            this.descricao = descricao;
            this.stock = stock;
            this.categoria = categoria;
            this.garantia = garantia;
            this.garantiatype = garantiaType;
            this.campanhaid = -1;
        }

        public void MostrarDados(Hashtable MarcaList) 
        {
            Marca marca = (Marca)MarcaList[this.marcaid];
            Console.WriteLine($"ID : {this.productid}\nProduto : {this.nome}\nTipo : {this.categoria}\nMarca : {marca.Nome}\nPreço : {this.price}\nDescrição : {this.descricao}");
        }
        public int ChecarGarantia() 
        {
            string s = "";
            if (this.garantiatype == GarantiaType.Dia) s = "days";
            else if (this.garantiatype == GarantiaType.Mes) s = "months";
            else s = "years";
            int aux = Extra.CalculateDifference(this.datacompra,DateTime.Now,s);
            if (aux < this.garantia) return 1;
            return 0;
        }
    }
}
