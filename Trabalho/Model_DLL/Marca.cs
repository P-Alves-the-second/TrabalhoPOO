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
    /// <summary>
    /// A classe <see cref="Marca"/> representa uma marca de produtos em um sistema e implementa a interface <see cref="IMarca"/>. 
    /// Ela contém informações sobre a marca, como seu nome, ID e os produtos associados a ela.
    /// </summary>
    public class Marca : IMarca
    {
        private string nome {  get; set; }
        private int idmarca {  get; set; }
        private List<int> products { get; set; }

        /// <summary>
        /// Lista de IDs de produtos associados a esta marca.
        /// </summary>
        public List<int> Products 
        {
            get=>products; 
            set => products = value;
        }

        /// <summary>
        /// Nome da marca.
        /// </summary>
        public string Nome 
        {
            get => nome;
            set => nome = value;
        }

        /// <summary>
        /// ID único da marca.
        /// </summary>
        public int IdMarca 
        {
            get  => idmarca;
            set => idmarca = value;
        }


        /// <summary>
        /// Construtor da classe <see cref="Marca"/> que inicializa a marca com um nome e ID.
        /// </summary>
        /// <param name="nome">Nome da marca.</param>
        /// <param name="idmarca">ID da marca.</param>
        public Marca(string nome,int idmarca) 
        {
            this.nome = nome;
            this.idmarca = idmarca;
        }

        /// <summary>
        /// Exibe os dados da marca no console, incluindo seu ID e nome.
        /// </summary>
        public void MostrarDados() 
        {
            Console.WriteLine($"Id : {this.idmarca}\nNome : {this.nome}");
        }

        /// <summary>
        /// Salva os dados da marca em um arquivo de texto no formato JSON. 
        /// Se o arquivo já existir, ele será sobrescrito.
        /// </summary>
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
