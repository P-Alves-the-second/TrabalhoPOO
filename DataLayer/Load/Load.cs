using BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Load
    {
        public static Hashtable LoadData(int op)
        {
            Hashtable List = new Hashtable();
            string[] caminhos = { "./Users.txt", "./Produtos.txt", "./Marcas.txt","./Campanhas.txt" };
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try
            {
                string caminho = caminhos[op];
                if (!File.Exists(caminho)) return List;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        switch (op)
                        {
                            case 0:
                                BusinessLayer.User user = JsonSerializer.Deserialize<BusinessLayer.User>(str, options);
                                List.Add(user.IdUser, user);
                                break;
                            case 1:
                                Produto produto = JsonSerializer.Deserialize<Produto>(str, options);
                                List.Add(produto.ProductId, produto);
                                break;
                            case 2:
                                Marca marca = JsonSerializer.Deserialize<Marca>(str, options);
                                List.Add(marca.IdMarca, marca);
                                break;
                            case 3:
                                Campanha campanha = JsonSerializer.Deserialize<Campanha>(str, options);
                                List.Add(campanha.CampanhaId, campanha);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(User): " + ex.Message);
                throw;
                return null;
            }
            return List;
        }
    }
}
