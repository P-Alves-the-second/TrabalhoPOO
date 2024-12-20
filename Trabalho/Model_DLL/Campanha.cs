using Enums_DLL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_DLL
{
    public class Campanha : ICampanha
    {
        public List<int> produtos { get; set; }
        private int campanhaid { get; set; }
        private string nome { get; set; }
        private string descricao { get; set; }
        private double desconto { get; set; }
        private DescontoType descontotype { get; set; }

        public int CampanhaId 
        {
            get => campanhaid;
            set => campanhaid = value;
        }
        public string Nome 
        {
            get => nome;
            set => nome = value;
        }
        public string Descricao 
        {
            get => descricao;
            set => descricao = value;
        }
        public double Desconto 
        {
            get => desconto;
            set => desconto = value;
        }
        public DescontoType DescontoType 
        {
            get => descontotype;
            set => descontotype = value;
        }

        public List<int> Produtos 
        {
            get=> produtos;
            set => produtos = value;
        }

        public Campanha(int CampanhaID,string Name,string Descricao,double Desconto,DescontoType descontoType) 
        {
            this.campanhaid = CampanhaID;
            this.nome = Name;
            this.descricao = Descricao;
            this.descontotype = descontoType;
            this.produtos = new List<int>();
        }
        public int AdicionarProduto(Hashtable ProductList,int product) 
        {
            Produto produto = (Produto)ProductList[product];
            if (produto.CampanhaId != -1) return 1;
            foreach (int i in this.produtos) if (produto.ProductId == i) return 2;
            this.produtos.Add(product);
            produto.CampanhaId = this.campanhaid;
            return 0;
        }
        public void MostrarDados(Hashtable ProductList) 
        {
            Console.WriteLine($"Id : {this.CampanhaId}\nNome : {this.nome}\nDescição : {this.descricao}");
            if(this.descontotype==DescontoType.porcentagem) Console.WriteLine($"Desconto : {this.desconto}%");
            else Console.WriteLine($" Desconto {this.desconto}$");
            Console.WriteLine("Produtos : ");
            foreach(int i in produtos) 
            {
                Console.WriteLine("----");
                Produto produto = (Produto)ProductList[i];
                Console.WriteLine($"Id : {produto.ProductId}\nNome :{produto.Nome}");
            }
        }
    }
}
