using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    public class Vendedor : User
    {
        private List<int> products;
        public override Hashtable Register(Hashtable UserList)
        {
            foreach(DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                if(user.Email == this.Email) return null;
            }
            UserList.Add(this.IdUser,this);
            return UserList;
        }

        public Hashtable AddNewProduct(Hashtable ProductList,Hashtable MarcaList,int productid,int marcaid, int price, string nome, string descricao, int stock, CategoriaProduto categoria) 
        {
            foreach(DictionaryEntry entry in MarcaList) 
            {
                Marca marca = (Marca)MarcaList[entry.Key];
                if (marcaid == marca.IdMarca) break;
                throw new IDNotFoundException("Marca Não encontrada");
            }

            Produto NovoProduto = new Produto(this.IdUser,productid,marcaid,price,nome,descricao,stock,categoria);
            ProductList.Add(NovoProduto.ProductId,NovoProduto);

            this.products.Add(NovoProduto.ProductId);

            Marca marca2 = (Marca)MarcaList[marcaid];
            marca2.products.Add(productid);

            return ProductList;
        }

        public Hashtable AddStock(Hashtable ProductList,int productid,int num) 
        {
            foreach(int product in this.products) 
            {
                if (product == productid) 
                {
                    Produto produto = (Produto)ProductList[product];
                    produto.Stock += num;
                }
                throw new IDNotFoundException("Produto não encontrado");
            }
            return ProductList;
        }

        public Hashtable AddMarca(Hashtable MarcaList,string nome,int marcaid) 
        {
            Marca marca = new Marca(nome,marcaid);
            MarcaList.Add(marcaid,marca);
            return MarcaList;
        }

        public void ShowProductList(Hashtable ProductList) 
        {
            foreach(int produto in this.products)
            {
                Produto storedprotuct = (Produto)ProductList[produto];
                Console.WriteLine($"{storedprotuct.ProductId}||{storedprotuct.Nome}||{storedprotuct.Price}");
            }
        }
        public Vendedor(string Name,string Email,string Password,int IdUser) : base(Name, Email, Password, IdUser, EUserType.Vendedor) 
        {
            this.products = new List<int> { };
        }
        
    }
}
