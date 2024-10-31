using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    public class Cliente : User
    {
        private List<int> compras;
        public override Hashtable Register(Hashtable UserList)
        {
            foreach (User user in UserList)
            {
                if (user.Email == this.Email) return null;
            }
            UserList.Add(this.IdUser,this);
            return UserList;
        }

        public void ComprarProduto(Hashtable ProductList,int produtoid,int quantidade) 
        {
            foreach(DictionaryEntry entry in ProductList) 
            {
                Produto produto = (Produto)ProductList[entry.Key];
                if(produto.ProductId == produtoid) 
                {
                    this.compras.Add(produto.ProductId);
                    produto.Stock-=quantidade;
                }
                throw new IDNotFoundException("Produto não encontrado");
            }
        }
        public Cliente(string Name, string Email, string Password,int IdUser) : base(Name, Email, Password,IdUser ,EUserType.Cliente) { }
    }
}
