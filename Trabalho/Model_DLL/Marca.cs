using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Model_DLL
{
    public class Marca : IMarca
    {
        private string nome {  get; set; }
        private int idmarca {  get; set; }
        private List<int> products { get; set; }

        public List<int> Products 
        {
            get=>products; 
            set => products = value;
        }

        public string Nome 
        {
            get => nome;
            set => nome = value;
        }

        public int IdMarca 
        {
            get  => idmarca;
            set => idmarca = value;
        }

        public Marca(string nome,int idmarca) 
        {
            this.nome = nome;
            this.idmarca = idmarca;
        }
        public void MostrarDados() 
        {
            Console.WriteLine($"Id : {this.idmarca}\nNome : {this.nome}");
        }

        public void Save()
        {
            string caminho = "./Marcas.txt";
            string jsonMarca;
            if (File.Exists(caminho)) File.Delete(caminho);
                try
                {
                    jsonMarca = JsonSerializer.Serialize(this);
                    File.AppendAllText(caminho, jsonMarca + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(Marca): " + ex.Message);
                }
            
        }

    }
}
