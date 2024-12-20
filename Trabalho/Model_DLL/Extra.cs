using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enums_DLL;


namespace Model_DLL
{
    public class Extra
    {
        public static int LogIn(Hashtable UserList,string email,string password,EUserType userType) 
        {
            
            foreach (DictionaryEntry entry in UserList)
            {
                Console.WriteLine($"{entry.Key}");
                Console.ReadKey();
                User user = (User)UserList[entry.Key];
                if (user.Email == email) 
                {
                    if(user.Password==password)return user.IdUser;
                }
                
            }
            Console.ReadKey();
            return -1;
        }
        public static void SaveUser(Hashtable UserList) 
        {
            string caminho = "./Users.txt";
            string jsonUser;
            if (File.Exists(caminho)) File.Delete(caminho);

            foreach (DictionaryEntry entry in UserList)
            {
                try
                {                
                    User user = (User)UserList[entry.Key];
                    if (user.UserType == EUserType.Cliente)
                    {
                        Cliente cliente = (Cliente)UserList[entry.Key];                        
                        jsonUser = JsonSerializer.Serialize(cliente);
                        //Console.WriteLine($"{jsonUser}");
                        File.AppendAllText(caminho, jsonUser + Environment.NewLine);

                    }
                    else
                    {
                        Vendedor vendedor = (Vendedor)UserList[entry.Key];
                        //Console.WriteLine($"{vendedor.Name}");
                        jsonUser = JsonSerializer.Serialize(vendedor);
                        File.AppendAllText(caminho, jsonUser + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(User): " + ex.Message);
                }
            }
        }
        public static void SaveProduto(Hashtable ProdutoList) 
        {
            string caminho = "./Produtos.txt";
            string jsonProduto;
            if (File.Exists(caminho)) File.Delete(caminho);

            foreach (DictionaryEntry entry in ProdutoList)
            {
                try
                {
                    Produto produto = (Produto)ProdutoList[entry.Key];
                    jsonProduto = JsonSerializer.Serialize(produto);
                    File.AppendAllText(caminho, jsonProduto + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(Produto): " + ex.Message);
                }
            }
        }
        public static void SaveMarca(Hashtable MarcaList) 
        {
            string caminho = "./Marcas.txt";
            string jsonMarca;
            if(File.Exists(caminho))File.Delete(caminho);
            foreach(DictionaryEntry entry in MarcaList) 
            {
                try 
                {
                    Marca marca = (Marca)MarcaList[entry.Key];
                    jsonMarca = JsonSerializer.Serialize(marca);
                    File.AppendAllText(caminho, jsonMarca + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(Marca): " + ex.Message);
                }
            }
        } 

        public static Hashtable LoadUser() 
        {
            Hashtable UserList = new Hashtable();
            string caminho = "./Users.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try
            {
                if (!File.Exists(caminho)) return UserList;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        User user = JsonSerializer.Deserialize<User>(str,options);
                        Console.WriteLine($"{str}");
                        UserList.Add(user.IdUser, user); 
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro ao carregar dados(User): " + ex.Message);
                return null;
            }
            return UserList;
        }

        public static Hashtable LoadProduct() 
        {
            Hashtable ProductList = new Hashtable();
            string caminho = "./Produtos.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try 
            {
                if (!File.Exists(caminho)) return ProductList;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings) 
                {
                    if (!string.IsNullOrWhiteSpace(str)) 
                    {
                        Produto produto = JsonSerializer.Deserialize<Produto>(str,options);
                        ProductList.Add(produto.ProductId,produto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(Produto): " + ex.Message);
                return ProductList;
            }
            return ProductList;
        }
        public static Hashtable LoadMarca() 
        {
            Hashtable MarcaList = new Hashtable();
            string caminho = "./Marcas.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try 
            {
                if(!File.Exists(caminho)) return MarcaList;
                string[] strings = File.ReadAllLines(caminho);
                foreach(string str in strings) 
                {
                    if (!string.IsNullOrWhiteSpace(str)) 
                    {
                        Marca marca = JsonSerializer.Deserialize<Marca>(str,options);
                        MarcaList.Add(marca.IdMarca,marca);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(Marca): " + ex.Message);
                return null;
            }
            return MarcaList;

        }
        public static void Save(Hashtable UserList,Hashtable ProdutoList,Hashtable MarcaList) 
        {
            SaveUser(UserList);
            SaveProduto(ProdutoList);
            SaveMarca(MarcaList);
        }

        public static void MostrarProdutos(Hashtable ProductList,Hashtable MarcaList) 
        {
            foreach(DictionaryEntry entry in ProductList) 
            {
                Produto produto = (Produto)ProductList[entry.Key];
                Console.WriteLine("----");
                produto.MostrarDados(MarcaList);
            }
        }
        public static void ApagarDados(int op) 
        {
            if(op==3 || op==0)File.Delete("./Marcas.txt");
            if(op==2 || op==0)File.Delete("./Produtos.txt");
            if(op==1 || op==0)File.Delete("./Users.txt");
        }
        public static int CalculateDifference(DateTime startDate, DateTime endDate, string unit)
        {
            switch (unit.ToLower())
            {
                case "days":
                    return (endDate - startDate).Days;
                case "months":
                    int months = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
                    if (endDate.Day < startDate.Day)
                        months--; // Ajusta se o dia do mês de fim for menor que o de início.
                    return months;
                case "years":
                    int years = endDate.Year - startDate.Year;
                    if (endDate.Month < startDate.Month ||
                       (endDate.Month == startDate.Month && endDate.Day < startDate.Day))
                        years--; // Ajusta se ainda não alcançou o aniversário completo.
                    return years;
                default:
                    throw new ArgumentException("Unidade inválida. Use 'days', 'months' ou 'years'.");
            }
        }
}
