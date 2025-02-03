using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// A classe <see cref="Cliente"/> herda da classe <see cref="User"/> e representa um cliente no sistema.
    /// Ela contém informações sobre as compras realizadas pelo cliente e métodos para exibir esses dados e realizar compras.
    /// </summary>
    public class Cliente : User
    {
        /// <summary>
        /// Lista de IDs dos produtos comprados pelo cliente.
        /// </summary>
        private List<int> compras { get; set; }

        /// <summary>
        /// Propriedade que acessa a lista de compras do cliente.
        /// </summary>
        public List<int> Compras
        {
            get => compras;
            set => compras = value;
        }

        /// <summary>
        /// Construtor padrão da classe <see cref="Cliente"/>. 
        /// Inicializa uma nova instância sem parâmetros.
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Construtor da classe <see cref="Cliente"/> que inicializa uma nova instância com os parâmetros fornecidos.
        /// </summary>
        /// <param name="Name">Nome do cliente.</param>
        /// <param name="Email">Email do cliente.</param>
        /// <param name="Password">Senha do cliente.</param>
        /// <param name="IdUser">ID do usuário (Cliente).</param>
        [JsonConstructor]
        public Cliente(string Name, string Email, string Password, int IdUser) : base(Name, Email, Password, IdUser, EUserType.Cliente)
        {
            this.compras = new List<int>();
        }

        /// <summary>
        /// Exibe os dados do cliente, incluindo o tipo de usuário (Cliente) e as compras realizadas.
        /// </summary>
        /// <param name="ProductList">Lista de produtos usados para mostrar as compras do cliente.</param>
        /// <param name="MarcaList">Lista de marcas usadas para mostrar informações adicionais (não utilizado no método atual).</param>
        public override void MostrarDados(Hashtable ProductList, Hashtable MarcaList)
        {
            base.MostrarDados(ProductList, MarcaList);
            Console.WriteLine($"Tipo : Cliente ");
            Console.WriteLine("Compras :");
            foreach (int i in this.compras)
            {
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"Id : {produto.ProductId} Nome : {produto.Nome} Data : {produto.DataCompra}");
            }
        }

        /// <summary>
        /// Realiza a compra de um produto, verificando se o produto está em estoque e se o cliente possui saldo suficiente.
        /// Se o produto estiver em uma campanha, aplica o desconto e debita o valor na carteira do cliente.
        /// </summary>
        /// <param name="ProductList">Lista de produtos disponíveis para compra.</param>
        /// <param name="VendedorList">Lista de vendedores responsáveis pelos produtos.</param>
        /// <param name="CampanhaList">Lista de campanhas que podem ser aplicadas aos produtos.</param>
        /// <param name="productid">ID do produto que o cliente deseja comprar.</param>
        /// <returns>
        /// 1 - Compra realizada com sucesso.
        /// 2 - Produto fora de estoque.
        /// 3 - Saldo insuficiente para a compra.
        /// </returns>
        public int Buy(Hashtable ProductList, Hashtable VendedorList, Hashtable CampanhaList, int productid)
        {
            Produto product = (Produto)ProductList[productid];
            Console.WriteLine($"{product.VendedorId}");
            Console.ReadLine();
            Vendedor vendedor = (Vendedor)VendedorList[product.VendedorId];

            if (product.Stock <= 0) return 2;

            if (product.CampanhaId != -1)
            {
                double newprice;
                Campanha campanha = (Campanha)CampanhaList[product.CampanhaId];
                if (campanha.DescontoType == DescontoType.valor) newprice = product.Price - campanha.Desconto;
                else newprice = product.Price * (campanha.Desconto / 100);
                if (this.Wallet < newprice) return 3;
                Console.WriteLine("Desconto de campanha aplicado");
                product.DataCompra = DateTime.Now;

                this.Wallet -= product.Price;
                this.compras.Add(product.ProductId);
                vendedor.addCash(product.Price);

            }
            else
            {
                if (this.Wallet < product.Price) return 3;
                product.DataCompra = DateTime.Now;

                this.Wallet -= product.Price;
                this.compras.Add(product.ProductId);
                vendedor.addCash(product.Price);
            }
            return 1;
        }
    }
}
