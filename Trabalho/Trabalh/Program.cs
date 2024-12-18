using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_DLL;    
using System.Collections;
using Enums_DLL;
using System.Security.AccessControl;

namespace Trabalho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int CurrentUser = -1;
            int CurrentUserId = 1;
            int CurrentProductId = 1;
            int CurrentMarcaId = 1;
            EUserType CurrentUserType = EUserType.Cliente;
            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();
            Hashtable MarcaList = new Hashtable();
            UserList = Extra.LoadUser();
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
                Console.Clear() ;
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
                Console.WriteLine("4 - Mostrar Marcas");
                Console.WriteLine("5 - Ver Perfil");
                Console.WriteLine("6 - Signout");
                Console.WriteLine("0 - Sair");

                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Extra.MostrarProdutos(ProductList, MarcaList);
                        Console.WriteLine("efwwdfe");
                        Console.ReadKey();
                        break;
                    case 2:
                        if (CurrentUserType == EUserType.Cliente)
                        {                          
                        }
                        else
                        {
                            int aux = 0;
                            Console.Clear();
                            Console.WriteLine("Id da Marca :");
                            int marcaid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Nome do Produto :");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Preço :");
                            double preco = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Descrição :");
                            string descricao = Console.ReadLine();
                            Console.WriteLine("Estoque :");
                            int stock = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Categoria do Produto : \n1 - roupas\n2 - sapatos\n3 - utensilios\n4 - eletronicos");
                            while (aux < 1 || aux > 4) aux = Convert.ToInt32(Console.ReadLine());
                            CategoriaProduto categoria = CategoriaProduto.sapatos;
                            switch (aux)
                            {
                                case 1:
                                    categoria = CategoriaProduto.roupas;
                                    break;
                                case 2:
                                    categoria = CategoriaProduto.sapatos;
                                    break;
                                case 3:
                                    categoria = CategoriaProduto.utensilios;
                                    break;
                                case 4:
                                    categoria = CategoriaProduto.eletronicos;
                                    break;
                            }
                            Console.WriteLine("Tipo de garantia :\n1 - dias\n2 - meses\n3 - anos");
                            aux = 0;
                            GarantiaType garantiatype = GarantiaType.Ano;
                            while (aux < 1 || aux > 3) aux = Convert.ToInt32(Console.ReadLine());
                            switch (aux)
                            {
                                case 1:
                                    garantiatype = GarantiaType.Dia;
                                    break;
                                case 2:
                                    garantiatype = GarantiaType.Mes;
                                    break;
                                case 3:
                                    garantiatype = GarantiaType.Ano;
                                    break;
                            }
                            Console.WriteLine("Garantia(quantidade) : ");
                            int garantia = Convert.ToInt32(Console.ReadLine());

                            Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                            Produto produto = new Produto(vendedor.IdUser, CurrentProductId, marcaid,preco,nome,descricao,stock,categoria,garantia,garantiatype);

                            ProductList.Add(produto.ProductId,produto);
                            CurrentProductId++;
                            vendedor.AddProduto(produto);
                        }                 
                        break;
                    case 3:
                        if (CurrentUserType == EUserType.Cliente)
                        {

                        }
                        else 
                        {
                            Console.Clear();
                            Console.WriteLine("Nome da marca");
                            string nome = Console.ReadLine();
                            Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                            MarcaList = vendedor.AddMarca(MarcaList,CurrentMarcaId,nome);
                            CurrentMarcaId++;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        foreach(DictionaryEntry entry in MarcaList) 
                        {
                            Marca marca = (Marca)MarcaList[entry.Key];
                            Console.WriteLine("----");
                            marca.MostrarDados();
                            Console.ReadKey();
                        }
                        break;
                }
            }

        }
    }
}
