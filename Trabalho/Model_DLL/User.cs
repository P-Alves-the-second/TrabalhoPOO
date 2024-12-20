﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums_DLL;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Model_DLL
{
    public abstract class User
    {
        private int iduser {  get; set; }
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private double wallet { get; set; }

        private EUserType usertype { get; set; }

        public double Wallet
        {
            get => wallet;
            set => wallet = value;
        }

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

        public User() { }

   
        public User(string name, string email, string password,int iduser,EUserType usertype)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.iduser = iduser;
            this.usertype = usertype;
            this.wallet = 0;
        }
        public virtual void MostrarDados(Hashtable ProductList,Hashtable MarcaList) { Console.WriteLine($"ID : {this.iduser}\nNome : {this.name}\nEmail : {this.email}\nSaldo : {this.wallet}"); }

        public Hashtable Register(Hashtable UserList) 
        {
            foreach (DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                if (user.email == this.email) return UserList;
            }
            UserList.Add(this.iduser, this);
            return UserList;
        }

        public void addCash(double quantidade)
        {
            this.Wallet += quantidade;
        }

        public void Save()
        {
            string caminho = "./Users.txt";
            string jsonUser;
            if (File.Exists(caminho)) File.Delete(caminho);        
                try
                { 
                    if (this.UserType == EUserType.Cliente)
                    {
                        jsonUser = JsonSerializer.Serialize(this);
                        //Console.WriteLine($"{jsonUser}");
                        File.AppendAllText(caminho, jsonUser + Environment.NewLine);

                    }
                    else
                    {
                        //Console.WriteLine($"{vendedor.Name}");
                        jsonUser = JsonSerializer.Serialize(this);
                        File.AppendAllText(caminho, jsonUser + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar dados(User): " + ex.Message);
                }
            
        }
    }
}
