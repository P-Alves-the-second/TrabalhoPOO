
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// A classe <see cref="Campanha"/> representa uma campanha de desconto no sistema.
    /// Ela implementa a interface <see cref="ICampanha"/> e contém informações sobre a campanha,
    /// incluindo seu ID, nome, descrição, tipo e valor do desconto, além dos produtos associados a ela.
    /// </summary>
    public class Campanha : ICampanha
    {
        /// <summary>
        /// Lista de IDs dos produtos associados à campanha.
        /// </summary>
        public List<int> produtos { get; set; }

        /// <summary>
        /// ID único da campanha.
        /// </summary>
        private int campanhaid { get; set; }

        /// <summary>
        /// Nome da campanha.
        /// </summary>
        private string nome { get; set; }

        /// <summary>
        /// Descrição da campanha.
        /// </summary>
        private string descricao { get; set; }

        /// <summary>
        /// Valor do desconto oferecido pela campanha.
        /// </summary>
        private double desconto { get; set; }

        /// <summary>
        /// Tipo do desconto oferecido pela campanha (porcentagem ou valor fixo).
        /// </summary>
        private DescontoType descontotype { get; set; }

        /// <summary>
        /// Propriedade que acessa o ID da campanha.
        /// </summary>
        public int CampanhaId
        {
            get => campanhaid;
            set => campanhaid = value;
        }

        /// <summary>
        /// Propriedade que acessa o nome da campanha.
        /// </summary>
        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        /// <summary>
        /// Propriedade que acessa a descrição da campanha.
        /// </summary>
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        /// <summary>
        /// Propriedade que acessa o valor do desconto da campanha.
        /// </summary>
        public double Desconto
        {
            get => desconto;
            set => desconto = value;
        }

        /// <summary>
        /// Propriedade que acessa o tipo de desconto da campanha (porcentagem ou valor fixo).
        /// </summary>
        public DescontoType DescontoType
        {
            get => descontotype;
            set => descontotype = value;
        }

        /// <summary>
        /// Propriedade que acessa a lista de produtos associados à campanha.
        /// </summary>
        public List<int> Produtos
        {
            get => produtos;
            set => produtos = value;
        }

        /// <summary>
        /// Construtor da classe <see cref="Campanha"/> que inicializa uma nova campanha com os parâmetros fornecidos.
        /// </summary>
        /// <param name="CampanhaID">ID da campanha.</param>
        /// <param name="Name">Nome da campanha.</param>
        /// <param name="Descricao">Descrição da campanha.</param>
        /// <param name="Desconto">Valor do desconto.</param>
        /// <param name="descontoType">Tipo de desconto (porcentagem ou valor fixo).</param>
        public Campanha(int CampanhaID, string Name, string Descricao, double Desconto, DescontoType descontoType)
        {
            this.campanhaid = CampanhaID;
            this.nome = Name;
            this.descricao = Descricao;
            this.descontotype = descontoType;
            this.produtos = new List<int>();
        }

        /// <summary>
        /// Adiciona um produto à campanha, se ele ainda não estiver associado a outra campanha.
        /// Retorna um código de erro:
        /// 0 - Produto adicionado com sucesso.
        /// 1 - Produto já pertence a outra campanha.
        /// 2 - Produto já está associado a esta campanha.
        /// </summary>
        /// <param name="ProductList">Lista de produtos.</param>
        /// <param name="product">ID do produto a ser adicionado.</param>
        /// <returns>Código de erro conforme descrito.</returns>
        public int AdicionarProduto(Hashtable ProductList, int product)
        {
            Produto produto = (Produto)ProductList[product];
            if (produto.CampanhaId != -1) return 1;
            foreach (int i in this.produtos) if (produto.ProductId == i) return 2;
            this.produtos.Add(product);
            produto.CampanhaId = this.campanhaid;
            return 0;
        }

        /// <summary>
        /// Exibe os detalhes da campanha, incluindo os produtos associados a ela.
        /// </summary>
        /// <param name="ProductList">Lista de produtos utilizados para mostrar os dados dos produtos associados.</param>
        public void MostrarDados(Hashtable ProductList)
        {
            Console.WriteLine($"Id : {this.CampanhaId}\nNome : {this.nome}\nDescição : {this.descricao}");
            if (this.descontotype == DescontoType.porcentagem) Console.WriteLine($"Desconto : {this.desconto}%");
            else Console.WriteLine($" Desconto {this.desconto}$");
            Console.WriteLine("Produtos : ");
            foreach (int i in produtos)
            {
                Console.WriteLine("----");
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"Id : {produto.ProductId}\nNome :{produto.Nome}");
            }
        }
    }
}
