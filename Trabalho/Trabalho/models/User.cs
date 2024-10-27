using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.enums;
using Trabalho.interfaces;

namespace Trabalho.models
{
    public abstract class User: IUser
    {
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }

        private EUserType usertype { get; set; } 

        public string Name  
        {
            get => name;
            set => name = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }

        public EUserType UserType 
        { 
            get => usertype;
            set => usertype = value;
        }

        public User LogIn(User[] UserList,string email,string password) 
        {
            foreach (User user in UserList) 
            {
                if (user.Email == email && user.Password == password) return user;
            }
            return null;
        }

        public virtual bool Register(List<User> UserList) { return false; }

        public User(string name, string email, string password,EUserType usertype)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = usertype;
        }
    }
}
