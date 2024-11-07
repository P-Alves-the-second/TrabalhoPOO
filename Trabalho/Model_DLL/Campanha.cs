using Enums_DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_DLL
{
    public class Campanha
    {
        public List<int> produtos;
        private int campanhaid;
        private string nome;
        private string descricao;
        private int desconto;
        private DescontoType descontotype;
        
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
        public int Desconto 
        {
            get => desconto;
            set => desconto = value;
        }
        public DescontoType DescontoType 
        {
            get => descontotype;
            set => descontotype = value;
        }

        public Campanha(int CampanhaID,string Name,string Descricao,int Desconto,DescontoType descontoType) 
        {
            this.campanhaid = CampanhaID;
            this.nome = Name;
            this.descricao = Descricao;
            this.descontotype = descontoType;
        }
    }
}
