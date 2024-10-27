using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.models;

using Trabalho.enums;

namespace Trabalho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> UserList = new List<User>();
            Vendedor ve = new Vendedor("wdsc","vcwd","vef");
            if(ve.Register(UserList))UserList.Add(ve);
            foreach (User user in UserList) 
            {
                Console.WriteLine($"{user.Name}");
            }
            Console.ReadLine();
        }
    }
}
