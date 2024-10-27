using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;

namespace Trabalho.models
{
    internal class Cliente : User
    {
        public override bool Register(List<User> UserList)
        {
            foreach (User user in UserList)
            {
                if (user.Email == this.Email) return false;
            }
            return true;
        }
        public Cliente(string Name, string Email, string Password) : base(Name, Email, Password, EUserType.Cliente) { }
    }
}
