using System;
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
    /// <summary>
    /// A classe <see cref="User"/> é uma classe abstrata que serve como base para as subclasses de utilizadores, representando dados e comportamentos comuns a todos os utilizadores, como identificação, nome, email, senha e saldo.
    /// </summary>
    public abstract class User
    {
        private int iduser {  get; set; }
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private double wallet { get; set; }

        private EUserType usertype { get; set; }

        /// <summary>
        /// Saldo atual do utilizador.
        /// </summary>
        public double Wallet
        {
            get => wallet;
            set => wallet = value;
        }

        /// <summary>
        /// Nome do utilizador.
        /// </summary>
        public string Name  
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Email do utilizador.
        /// </summary>
        public string Email
        {
            get => email;
            set => email = value;
        }

        /// <summary>
        /// Senha do utilizador.
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }

        /// <summary>
        /// Tipo do utilizador (Cliente ou Vendedor).
        /// </summary>
        public EUserType UserType 
        { 
            get => usertype;
            set => usertype = value;
        }

        /// <summary>
        /// ID único do utilizador.
        /// </summary>
        public int IdUser 
        {
            get => iduser;
            set => iduser = value;
        }

        /// <summary>
        /// Construtor padrão da classe <see cref="User"/>.
        /// </summary>
        public User() { }

        /// <summary>
        /// Construtor da classe <see cref="User"/> que inicializa os atributos básicos do utilizador.
        /// </summary>
        /// <param name="name">Nome do utilizador.</param>
        /// <param name="email">Email do utilizador.</param>
        /// <param name="password">Senha do utilizador.</param>
        /// <param name="iduser">ID do utilizador.</param>
        /// <param name="usertype">Tipo do utilizador (Cliente ou Vendedor).</param>
        public User(string name, string email, string password,int iduser,EUserType usertype)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.iduser = iduser;
            this.usertype = usertype;
            this.wallet = 0;
        }
        /// <summary>
        /// Exibe as informações do utilizador, incluindo ID, nome, email e saldo.
        /// </summary>
        /// <param name="ProductList">Hashtable contendo os produtos.</param>
        /// <param name="MarcaList">Hashtable contendo as marcas.</param>
        public virtual void MostrarDados(Hashtable ProductList,Hashtable MarcaList) { Console.WriteLine($"ID : {this.iduser}\nNome : {this.name}\nEmail : {this.email}\nSaldo : {this.wallet}"); }


        /// <summary>
        /// Registra um novo utilizador na lista de usuários, verificando se o email já está cadastrado.
        /// </summary>
        /// <param name="UserList">Hashtable contendo os usuários registrados.</param>
        /// <returns>A lista de usuários com o novo usuário adicionado, ou a lista original se o email já existir.</returns>
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

        /// <summary>
        /// Adiciona uma quantia ao saldo (wallet) do utilizador.
        /// </summary>
        /// <param name="quantidade">Quantia a ser adicionada ao saldo do utilizador.</param>
        public void addCash(double quantidade)
        {
            this.Wallet += quantidade;
        }


        /// <summary>
        /// Salva os dados do utilizador em um arquivo de texto no formato JSON. Se o arquivo já existir, ele será sobrescrito.
        /// </summary>
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
