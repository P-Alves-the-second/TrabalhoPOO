using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.models
{
    public class Campanha
    {
        public List<int> produtos;
        private int campanhaid;
        private string nome;
        private string descricao;
        
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
    }
}
