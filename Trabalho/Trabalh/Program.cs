using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_DLL;    
using System.Collections;
using Enums_DLL;

namespace Trabalho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();
            Hashtable MarcaList = new Hashtable();
            Cliente Cli = new Cliente("Pedro", "pedro@alves", "password", 1);

            Marca nike = new Marca("nike",1);
            MarcaList.Add(nike.IdMarca,nike);

            Produto Produto1 = new Produto(1,1,1,12,"tenis","Tenis",122,CategoriaProduto.sapatos);
            Produto Produto2 = new Produto(1, 2, 1, 12, "tenis2", "Tenis", 102, CategoriaProduto.sapatos);
            ProductList.Add(Produto1.ProductId,Produto1);
            ProductList.Add(Produto2.ProductId,Produto2);

            foreach (DictionaryEntry entry in ProductList)
            {
                Produto produto = (Produto)ProductList[entry.Key];
                produto.MostrarDados(MarcaList);
            }

            Cli.MostrarDados();
            foreach (DictionaryEntry entry in UserList)
            {
                User user = (User)UserList[entry.Key];
                Console.WriteLine($"{user.Name}");
            }
            Console.ReadLine();
        }
    }
}
