using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.models;

using Trabalho.enums;
using System.Collections;

namespace Trabalho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();

            Vendedor Ven = new Vendedor("Pedro","Pedro@Alves","password",1);
            Vendedor Ven2 = new Vendedor("Miguel", "Pedro@Alves","passswroerd",2);
            UserList = Ven.Register(UserList);
            UserList = Ven2.Register(UserList);
            foreach(DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                Console.WriteLine($"{user.Name}");
            }
            Ven.ShowProductList(ProductList);
            Console.ReadLine();
        }
    }
}
