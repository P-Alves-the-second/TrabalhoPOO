using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums_DLL;

namespace Model_DLL
{
    public class Cliente : User
    {
        private List<int> compras;
        public Cliente(string Name, string Email, string Password,int IdUser) : base(Name, Email, Password,IdUser ,EUserType.Cliente) { }

        public override void MostrarDados()
        {
            base.MostrarDados();
            Console.WriteLine($"Tipo : {EUserType.Cliente}");
        }
    }

    
}
