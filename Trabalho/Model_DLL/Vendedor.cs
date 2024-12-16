using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Enums_DLL;

namespace Model_DLL
{
    public class Vendedor : User
    {
        private List<int> products;
        public List<int> Products
        {
            get => products; 
            set => products = value;
        }
        public List<int> marcas;

        public List<int> Marcas 
        {
            get => marcas;
            set => marcas = value;
        }

        [JsonConstructor]
        public Vendedor(string Name,string Email,string Password,int IdUser) : base(Name, Email, Password, IdUser, EUserType.Vendedor) 
        {
            this.products = new List<int> { };
        }
        public override void MostrarDados()
        {
            base.MostrarDados();
            Console.WriteLine($"Tipo : {EUserType.Vendedor}");
        }
        public void AddProduto(Produto produto) 
        {
            this.products.Add(produto.ProductId);   
        }

        public Hashtable AddStock(Hashtable ProductList,int productid,int quant) 
        {
            Produto produto = (Produto)ProductList[productid];
            produto.Stock += quant;
            return ProductList;
        }

        public Hashtable AddMarca(Hashtable MarcaList,int marcaid,string nome) 
        {
            Marca marca = new Marca(nome,marcaid);
            MarcaList.Add(marcaid, marca);
            marcas.Add(marcaid);
            return MarcaList;
        }
    }
}
