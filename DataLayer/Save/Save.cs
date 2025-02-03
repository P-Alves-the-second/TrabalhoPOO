using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Save
    {
        public static void SaveData(User user, Produto produto, Marca marca, int op)
        {
            string[] caminhos = { "./Users.txt", "./Produtos.txt", "./Marcas.txt" };
            string json;
            string caminho = caminhos[op];

            
            try
            {
                switch (op)
                {
                    case 0:
                        if (user.UserType == EUserType.Cliente)
                        {
                            json = JsonSerializer.Serialize(user);
                            //Console.WriteLine($"{jsonUser}");
                            File.AppendAllText(caminho, json + Environment.NewLine);

                        }
                        else
                        {
                            //Console.WriteLine($"{vendedor.Name}");
                            json = JsonSerializer.Serialize(user);
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar dados(User): " + ex.Message);
            }

        }
    }
}
