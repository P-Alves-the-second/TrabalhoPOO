using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    public class Vendedor : User
    {
        private List<int> products;
        
        
        public Vendedor(string Name,string Email,string Password,int IdUser) : base(Name, Email, Password, IdUser, EUserType.Vendedor) 
        {
            this.products = new List<int> { };
        }
        
    }
}
