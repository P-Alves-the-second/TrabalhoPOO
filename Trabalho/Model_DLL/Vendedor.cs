using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Enums_DLL;
using Interfaces;

namespace Model_DLL
{
    /// <summary>
    /// Representa um vendedor no sistema. A classe herda de <see cref="User"/> e implementa a interface <see cref="IVendedor"/>.
    /// Ela contém informações sobre os produtos e marcas associados ao vendedor, além de métodos para manipulação desses dados.
    /// </summary>
    public class Vendedor : User, IVendedor
    {
        private List<int> products { get; set; }
        private List<int> marcas { get; set; }

        /// <summary>
        /// Obtém ou define a lista de IDs dos produtos associados ao vendedor.
        /// </summary>
        public List<int> Products
        {
            get => products; 
            set => products = value;
        }

        /// <summary>
        /// Obtém ou define a lista de IDs das marcas associadas ao vendedor.
        /// </summary>
        public List<int> Marcas 
        {
            get => marcas;
            set => marcas = value;
        }

        /// <summary>
        /// Construtor da classe <see cref="Vendedor"/> que inicializa o vendedor com nome, email, senha, e ID do usuário,
        /// e define o tipo de usuário como <see cref="EUserType.Vendedor"/>.
        /// </summary>
        /// <param name="Name">Nome do vendedor.</param>
        /// <param name="Email">E-mail do vendedor.</param>
        /// <param name="Password">Senha do vendedor.</param>
        /// <param name="IdUser">ID do vendedor.</param>
        [JsonConstructor]
        public Vendedor(string Name,string Email,string Password,int IdUser) : base(Name, Email, Password, IdUser, EUserType.Vendedor) 
        {
            this.products = new List<int> { };
            this.marcas = new List<int> { };
        }

        /// <summary>
        /// Exibe as informações do vendedor, incluindo produtos e marcas associadas.
        /// </summary>
        /// <param name="ProductList">Lista de produtos carregados no sistema, usando o ID como chave.</param>
        /// <param name="MarcaList">Lista de marcas carregadas no sistema, usando o ID como chave.</param>
        public override void MostrarDados(Hashtable ProductList, Hashtable MarcaList)
        {
            base.MostrarDados(ProductList, MarcaList);
            Console.WriteLine($"Tipo : Vendedor");
            Console.WriteLine("Produtos : ");
            Console.WriteLine("---");
            foreach (int i in products) 
            {
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"Id : {produto.ProductId}\nNome : {produto.Nome}");
            }
            Console.WriteLine("---");
            foreach (int i in marcas) 
            {
                Marca marca = (Marca)MarcaList[i];
                Console.WriteLine($"Id : {marca.IdMarca}\nNome : {marca.Nome}");
            }
        }

        /// <summary>
        /// Adiciona um produto à lista de produtos do vendedor.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        public void AddProduto(Produto produto) 
        {
            this.products.Add(produto.ProductId);   
        }

        /// <summary>
        /// Adiciona uma quantidade ao estoque de um produto.
        /// </summary>
        /// <param name="ProductList">Lista de produtos carregados no sistema, usando o ID como chave.</param>
        /// <param name="productid">ID do produto a ser atualizado.</param>
        /// <param name="quant">Quantidade a ser adicionada ao estoque.</param>
        /// <returns>Lista de produtos atualizada.</returns>
        public Hashtable AddStock(Hashtable ProductList,int productid,int quant) 
        {
            Produto produto = (Produto)ProductList[productid];
            produto.Stock += quant;
            return ProductList;
        }

        /// <summary>
        /// Adiciona uma nova marca à lista de marcas do vendedor.
        /// </summary>
        /// <param name="MarcaList">Lista de marcas carregadas no sistema.</param>
        /// <param name="marcaid">ID da nova marca.</param>
        /// <param name="nome">Nome da nova marca.</param>
        /// <returns>Lista de marcas atualizada.</returns>
        public Hashtable AddMarca(Hashtable MarcaList,int marcaid,string nome) 
        {
            Marca marca = new Marca(nome,marcaid);
            MarcaList.Add(marcaid, marca);
            this.marcas.Add(marcaid);
            return MarcaList;
        }
    }
}
