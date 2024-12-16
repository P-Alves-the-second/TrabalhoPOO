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
        public static int LogIn(Hashtable UserList,string email,string password) 
        {
            int CurrentUser = -1;
            foreach(DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                if(user.Email == email) 
                {
                    if(user.Password == password) CurrentUser = user.IdUser;
                    break;
                }
            }
            return CurrentUser;
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
                        File.AppendAllText(caminho, jsonUser + Environment.NewLine);

                    }
                    else
                    {
                        Vendedor vendedor = (Vendedor)UserList[entry.Key];
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
                    File.AppendAllText(caminho, jsonProduto);
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
                    File.AppendAllText(caminho, jsonMarca+"\n");
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
            try
            {
                if (!File.Exists(caminho)) return null;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        User user = JsonSerializer.Deserialize<User>(str);
                        Console.WriteLine($"{str}");
                        UserList.Add(user.IdUser, user); 
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro ao carregar dados: " + ex.Message);
                return null;
            }
            return UserList;
        }
        public static void Save(Hashtable UserList,Hashtable ProdutoList,Hashtable MarcaList) 
        {
            SaveUser(UserList);
            SaveProduto(ProdutoList);
            SaveMarca(MarcaList);
        }
    }
}
