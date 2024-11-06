using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_DLL;
using Enums_DLL;

namespace Model_DLL
{
    public abstract class User: IUser
    {
        private int iduser {  get; set; }
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

        public int IdUser 
        {
            get => iduser;
            set => iduser = value;
        }

        public User(string name, string email, string password,int iduser,EUserType usertype)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.iduser = iduser;
            this.usertype = usertype;
        }
        public virtual void MostrarDados() { Console.WriteLine($"ID : {this.iduser}\nNome : {this.name}\nEmail : {this.email}"); }
    }
}
