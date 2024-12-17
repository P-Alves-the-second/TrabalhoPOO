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
            int CurrentUser = -1;
            int CurrentUserId = 1;
            EUserType CurrentUserType = EUserType.Cliente;
            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();
            Hashtable MarcaList = new Hashtable();
            int i = 1;

            while (i != 0)
            {
                
                while (CurrentUser == -1)
                {
                    int aux = 0;
                    while (aux != 1 && aux != 2)
                    {
                        Console.WriteLine("1 - LogIn\n2 - Registar\n0 - Sair");
                        aux = Convert.ToInt32(Console.ReadLine());
                        if(aux==0)Environment.Exit(0);
                    }
                    Console.Clear();
                    if (aux == 1) 
                    {
                        aux = 0;
                        while (aux != 1 && aux != 2)
                        {
                            Console.WriteLine("----LogIn----");
                            Console.WriteLine("1 - Vendedor");
                            Console.WriteLine("2 - Cliente");
                            aux = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Email : ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Senha : ");
                        string senha = Console.ReadLine();

                        if (aux == 1) CurrentUserType = EUserType.Vendedor;
                        else CurrentUserType = EUserType.Cliente;
                        CurrentUser = Extra.LogIn(UserList, email, senha, CurrentUserType);
                        Console.Clear();
                    }
                    else 
                    {
                        EUserType UserType = EUserType.Vendedor;
                        aux = 0;
                        while (aux != 1 && aux != 2)
                        {
                            Console.WriteLine("----Registar----");
                            Console.WriteLine("1 - Vendedor");
                            Console.WriteLine("2 - Cliente");
                            aux = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine("Nome : ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Email : ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Senha : ");
                        string password = Console.ReadLine();

                        if (aux==2) 
                        { 
                            Cliente user = new Cliente(nome,email,password,CurrentUserId);
                            UserList = user.Register(UserList);
                        }
                        else 
                        { 
                            Vendedor user = new Vendedor(nome,email,password,CurrentUserId); 
                            UserList = user.Register(UserList);
                        }
                        CurrentUserId++;
                        Extra.SaveUser(UserList);
                        Console.ReadKey();
                        Console.Clear();
                    }
                           
                    
                }

                Console.WriteLine("----Menu----");
                Console.WriteLine("1 - Mostrar Produtos");
                if (CurrentUserType == EUserType.Cliente)
                {
                    Console.WriteLine("2 - Comprar Produto\n3 - Adicionar Dinheiro");

                }
                else
                {
                    Console.WriteLine("2 - Adicionar Produto\n3 - Adicionar Marca");
                }
                Console.WriteLine("4 - Ver Perfil");
                Console.WriteLine("5 - Signout");
                Console.WriteLine("0 - Sair");

                i = Convert.ToInt32(Console.ReadLine());

                switch (i) 
                {
                    case 1:
                        break;
                }
            }

        }
    }
}
