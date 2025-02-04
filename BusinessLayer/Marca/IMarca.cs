using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IMarca
    {
        string Nome { get; set; }
        int IdMarca { get; set; }
        List<int> Products { get; set; }
        public string MostrarDados();
    }
}
