using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhooPooO;

namespace PresentationLayer
{
    public partial class Menu : Form
    {
        /// <summary>
        /// Variável que armazena o usuário atualmente logado. -1 significa nenhum usuário logado.
        /// </summary>
        int CurrentUser = -1;

        /// <summary>
        /// Identificadores únicos incrementais para usuários, produtos, marcas e campanhas.
        /// </summary>
        int CurrentUserId = 1;
        int CurrentProductId = 1;
        int CurrentMarcaId = 1;
        int CurrentCampanhaId = 1;

        /// <summary>
        /// Tipo de usuário atual. Inicialmente definido como Cliente.
        /// </summary>
        EUserType CurrentUserType = EUserType.Vendedor;

        /// <summary>
        /// Listas hash para armazenar usuários, produtos, marcas e campanhas.
        /// </summary>
        Hashtable UserList = new Hashtable();
        Hashtable ProductList = new Hashtable();
        Hashtable MarcaList = new Hashtable();
        Hashtable CampanhaList = new Hashtable();
        public Menu(int currentuserid, int currentuser)
        {
            InitializeComponent();
            this.CurrentUser = currentuser;
            this.CurrentUserId = currentuserid;
            UserList = DataLayer.Load.LoadData(0);

            User user = (User)UserList[currentuser];

            label1.Text = $"Utilizador : {user.Name}\nID : {user.IdUser}";

            this.CurrentUserType = user.UserType;

            if (CurrentUserType == EUserType.Cliente)
            {
                button2.Text = "Comprar Produto";
                button3.Text = "Adicionar Dinheiro";
                button4.Text = "Checar Garantia";
            }
            else
            {
                button2.Text = "Adicionar Produto";
                button3.Text = "Adicionar Marca";
                button4.Text = "Adicionar Campanha";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProductList = DataLayer.Load.LoadData(1);
            MarcaList = DataLayer.Load.LoadData(2);

            string data = "";
            string aux;

            foreach (DictionaryEntry entry in ProductList)
            {
                Produto produto = (Produto)ProductList[entry.Key];
                aux = produto.MostrarDados(MarcaList);
                data += aux;
            }
            MessageBox.Show(data);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentUserType == EUserType.Vendedor) 
            {

                MarcaList = DataLayer.Load.LoadData(2);

                Form AdicionarProduto = new AdicionarProduto(MarcaList,CurrentUser);

                AdicionarProduto.StartPosition = FormStartPosition.Manual;
                AdicionarProduto.Location = this.Location;

                this.Hide();
                AdicionarProduto.Show();

                AdicionarProduto.FormClosed += (s, args) => this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            if(CurrentUserType == EUserType.Vendedor) 
            {
                Form AdicionarMarca = new AdicionarMarca();

                AdicionarMarca.StartPosition = FormStartPosition.Manual;
                AdicionarMarca.Location = this.Location;

                this.Hide();
                AdicionarMarca.Show();

                AdicionarMarca.FormClosed += (s, args) => this.Show();
            }
            else 
            {
            
            }
        }
    }
}
