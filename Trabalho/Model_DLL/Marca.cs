using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_DLL
{
    public class Marca
    {
        private string nome {  get; set; }
        private int idmarca {  get; set; }

        public List<int> products;

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

    }
}
