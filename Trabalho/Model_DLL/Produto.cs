using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enums_DLL;
using Interfaces;

namespace Model_DLL
{
    /// <summary>
    /// A classe <see cref="Produto"/> representa um produto no sistema, contendo informações como preço, descrição, garantia, categoria, e outros atributos relacionados a um produto específico.
    /// </summary>
    public class Produto : IProduto
    {
        private int vendedorid {  get; set; }
        private int productid {  get; set; }
        private int campanhaid {  get; set; }
        private int marcaid {  get; set; }
        private double price {  get; set; }
        private string nome { get; set; }
        private string descricao { get; set; }
        private int stock {  get; set; }

        private int garantia { get; set; }

        private DateTime datacompra {  get; set; }
        private CategoriaProduto categoria { get; set; }
        private GarantiaType garantiatype { get; set; }

        /// <summary>
        /// ID do vendedor associado ao produto.
        /// </summary>
        public int VendedorId 
        {
            get => vendedorid;
            set => vendedorid = value;
        }

        /// <summary>
        /// ID único do produto.
        /// </summary>
        public int ProductId
        {
            get => productid;
            set => productid = value;
        }

        /// <summary>
        /// ID da marca do produto.
        /// </summary>
        public int MarcaId 
        {
            get => marcaid;
            set => marcaid = value;
        }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public double Price
        {
            get => price;
            set => price = value;
        }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome 
        {
            get => nome;
            set => nome = value;
        }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao 
        {
            get => descricao;
            set => descricao = value;
        }


        /// <summary>
        /// Quantidade em estoque do produto.
        /// </summary>
        public int Stock 
        {
            get => stock;
            set => stock = value;
        }

        /// <summary>
        /// Categoria do produto.
        /// </summary>
        public CategoriaProduto Categoria 
        {
            get => categoria;
            set => categoria = value;
        }

        /// <summary>
        /// Data da compra do produto.
        /// </summary>
        public DateTime DataCompra 
        {
            get => datacompra;
            set => datacompra = value;
        }

        /// <summary>
        /// Duração da garantia do produto.
        /// </summary>
        public int Garantia 
        {
            get => garantia;
            set => garantia = value;
        }

        /// <summary>
        /// Tipo de garantia do produto (em dias, meses ou anos).
        /// </summary>
        public GarantiaType GarantiaType 
        {
            get => garantiatype;
            set => garantiatype = value;
        }

        /// <summary>
        /// ID da campanha associada ao produto. Caso não haja campanha, o valor é -1.
        /// </summary>
        public int CampanhaId
        {
            get => campanhaid;
            set => campanhaid = value;
        }

        /// <summary>
        /// Construtor da classe <see cref="Produto"/> que inicializa os atributos do produto.
        /// </summary>
        /// <param name="vendedorid">ID do vendedor.</param>
        /// <param name="productid">ID do produto.</param>
        /// <param name="marcaid">ID da marca do produto.</param>
        /// <param name="price">Preço do produto.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição do produto.</param>
        /// <param name="stock">Quantidade em estoque do produto.</param>
        /// <param name="categoria">Categoria do produto.</param>
        /// <param name="garantia">Duração da garantia do produto.</param>
        /// <param name="garantiaType">Tipo de garantia (dias, meses, anos).</param>
        public Produto(int vendedorid, int productid,int marcaid, double price, string nome, string descricao, int stock, CategoriaProduto categoria, int garantia ,GarantiaType garantiaType)
        {
            this.vendedorid = vendedorid;
            this.productid = productid;
            this.marcaid = marcaid;
            this.price = price;
            this.nome = nome;
            this.descricao = descricao;
            this.stock = stock;
            this.categoria = categoria;
            this.garantia = garantia;
            this.garantiatype = garantiaType;
            this.campanhaid = -1;
        }

        /// <summary>
        /// Exibe as informações detalhadas do produto, incluindo seu ID, nome, categoria, marca, preço e descrição.
        /// </summary>
        /// <param name="MarcaList">Hashtable contendo as marcas associadas aos produtos.</param>
        public void MostrarDados(Hashtable MarcaList) 
        {
            Marca marca = (Marca)MarcaList[this.marcaid];
            Console.WriteLine($"ID : {this.productid}\nProduto : {this.nome}\nTipo : {this.categoria}\nMarca : {marca.Nome}\nPreço : {this.price}\nDescrição : {this.descricao}");
        }

        /// <summary>
        /// Verifica se o produto ainda está dentro do período de garantia, com base na data de compra e no tipo de garantia.
        /// </summary>
        /// <returns>1 se o produto ainda estiver dentro do período de garantia, 0 caso contrário.</returns>
        public int ChecarGarantia() 
        {
            string s = "";
            if (this.garantiatype == GarantiaType.Dia) s = "days";
            else if (this.garantiatype == GarantiaType.Mes) s = "months";
            else s = "years";
            int aux = Extra.CalculateDifference(this.datacompra,DateTime.Now,s);
            if (aux < this.garantia) return 1;
            return 0;
        }

        /// <summary>
        /// Salva os dados do produto em um arquivo de texto no formato JSON. Se o arquivo já existir, ele será sobrescrito.
        /// </summary>
        public void Save()
        {
            string caminho = "./Produtos.txt";
            string jsonProduto;
            if (File.Exists(caminho)) File.Delete(caminho);
                try
                {
                    jsonProduto = JsonSerializer.Serialize(this);
                    File.AppendAllText(caminho, jsonProduto + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(Produto): " + ex.Message);
                }
        }
    }
}
