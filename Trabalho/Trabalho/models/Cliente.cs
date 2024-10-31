using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    public class Cliente : User
    {
        private List<int> compras;
        public Cliente(string Name, string Email, string Password,int IdUser) : base(Name, Email, Password,IdUser ,EUserType.Cliente) { }
    }
}
