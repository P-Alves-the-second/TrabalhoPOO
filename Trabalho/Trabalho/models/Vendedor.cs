using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    internal class Vendedor : User
    {
        public override bool Register(List<User> UserList)
        {
            foreach(User user in UserList) 
            {
                if(user.Email == this.Email) return false;
            }
            return true;
        }
        public Vendedor(string Name,string Email,string Password) : base(Name, Email, Password,EUserType.Vendedor) { }
        
    }
}
