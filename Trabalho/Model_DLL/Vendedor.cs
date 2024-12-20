using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Enums_DLL;
using Interfaces;

namespace Model_DLL
{
    public class Vendedor : User, IVendedor
    {
        private List<int> products { get; set; }
        private List<int> marcas { get; set; }
        public List<int> Products
        {
            get => products; 
            set => products = value;
        }
        public List<int> Marcas 
        {
            get => marcas;
            set => marcas = value;
        }

        [JsonConstructor]
        public Vendedor(string Name,string Email,string Password,int IdUser) : base(Name, Email, Password, IdUser, EUserType.Vendedor) 
        {
            this.products = new List<int> { };
            this.marcas = new List<int> { };
        }
        public override void MostrarDados(Hashtable ProductList, Hashtable MarcaList)
        {
            base.MostrarDados(ProductList, MarcaList);
            Console.WriteLine($"Tipo : Vendedor");
            Console.WriteLine("Produtos : ");
            Console.WriteLine("---");
            foreach (int i in products) 
            {
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"Id : {produto.ProductId}\nNome : {produto.Nome}");
            }
            Console.WriteLine("---");
            foreach (int i in marcas) 
            {
                Marca marca = (Marca)MarcaList[i];
                Console.WriteLine($"Id : {marca.IdMarca}\nNome : {marca.Nome}");
            }
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
            this.marcas.Add(marcaid);
            return MarcaList;
        }
    }
}
