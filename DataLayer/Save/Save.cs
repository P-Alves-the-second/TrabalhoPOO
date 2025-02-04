using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Save
    {
        public static void SaveData(Hashtable UserList,User user, Produto produto, Marca marca,Campanha campanha, int op)
        {
            string[] caminhos = { "./Users.txt", "./Produtos.txt", "./Marcas.txt","./Campanhas.txt" };
            string json;
            string caminho = caminhos[op];
            try
            {
                switch (op)
                {
                    case 0:
                        if (user.UserType == EUserType.Cliente)
                        {
                            Cliente cliente = (Cliente)UserList[user.IdUser];
                            json = JsonSerializer.Serialize(cliente);
                            //Console.WriteLine($"{jsonUser}");
                            File.AppendAllText(caminho, json + Environment.NewLine);

                        }
                        else
                        {
                            Vendedor vendedor = (Vendedor)UserList[user.IdUser];
                            //Console.WriteLine($"{vendedor.Name}");
                            json = JsonSerializer.Serialize(vendedor);
                            File.AppendAllText(caminho, json + Environment.NewLine);
                        }
                        break;
                    case 1:
                        json = JsonSerializer.Serialize(produto);
                        File.AppendAllText(caminho, json + Environment.NewLine);
                        break;
                    case 2:
                        json = JsonSerializer.Serialize(marca);
                        File.AppendAllText(caminho, json + Environment.NewLine);
                        break;
                    case 3:
                        json = JsonSerializer.Serialize(campanha);
                        File.AppendAllText(caminho, json + Environment.NewLine);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar dados(User): " + ex.Message);
            }

        }
    }
}
