using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Enums_DLL;

namespace Model_DLL
{
    public class Cliente : User
    {
        private List<int> compras;
        public List<int> Compras
        {
            get=>compras;
            set=>compras = value;
        }
        public Cliente() { }

        [JsonConstructor]
        public Cliente(string Name, string Email, string Password,int IdUser) : base(Name, Email, Password,IdUser ,EUserType.Cliente) 
        {
            this.compras = new List<int>();
        }

        public override void MostrarDados(Hashtable ProductList, Hashtable MarcaList)
        {
            base.MostrarDados(ProductList,MarcaList);
            Console.WriteLine($"Tipo : Cliente ");
            Console.WriteLine("Compras :");
            foreach (int i in this.compras) 
            {
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"{produto.Nome} Data : {produto.DataCompra}");
            }
        }

        public int Buy(Hashtable ProductList,Hashtable VendedorList,Hashtable CampanhaList,int productid) 
        {
            Produto product = (Produto)ProductList[productid];
            Console.WriteLine($"{product.VendedorId}");
            Console.ReadLine();
            Vendedor vendedor = (Vendedor)VendedorList[product.VendedorId];

            if (product.Stock <= 0) return 2;

            if (product.CampanhaId != -1)
            {
                double newprice;
                Campanha campanha = (Campanha)CampanhaList[product.CampanhaId];
                if (campanha.DescontoType == DescontoType.valor) newprice = product.Price - campanha.Desconto;
                else newprice = product.Price * (campanha.Desconto / 100);
                if (this.Wallet < newprice) return 3;
                Console.WriteLine("Desconto de campanha aplicado");
                product.DataCompra = DateTime.Now;

                this.Wallet -= product.Price;
                //this.compras.Add(product.ProductId);
                vendedor.addCash(product.Price);

            }
            else
            {
                if (this.Wallet < product.Price) return 3;
                product.DataCompra = DateTime.Now;

                this.Wallet -= product.Price;
                //this.compras.Add(product.ProductId);
                vendedor.addCash(product.Price);
            }
            return 1;     
        }
    }

    
}
