using BusinessLayer;
using DataLayer;
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
                button4.Text = "Gerir Campanhas";

            }
            DataLayer.Logging.Log("Foi aberto o " + this.Name);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            UserList = DataLayer.Load.LoadData(0);
            ProductList = DataLayer.Load.LoadData(1);
            MarcaList = DataLayer.Load.LoadData(2);

            User user = (User)UserList[CurrentUser];
            string str = "";

            if (user.UserType == EUserType.Vendedor)
            {
                Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                str = vendedor.MostrarDados(ProductList, MarcaList);
            }
            else
            {
                Cliente cliente = (Cliente)UserList[CurrentUser];
                str = cliente.MostrarDados(ProductList, MarcaList);
            }

            MessageBox.Show(str);
            Logging.Log("Foi mostrado um perfil de utilizador");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Logging.Log("O utilizador saiu da conta");
            Application.Restart();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProductList = DataLayer.Load.LoadData(1);
            MarcaList = DataLayer.Load.LoadData(2);

            string data = "";
            string aux;
            int i = 0;

            foreach (DictionaryEntry entry in ProductList)
            {
                Produto produto = (Produto)ProductList[entry.Key];
                aux = produto.MostrarDados(MarcaList);
                data += aux;
                i++;
            }

            Logging.Log($"Foram mostrados {i} produtos");

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

                Form AdicionarProduto = new AdicionarProduto(MarcaList, CurrentUser);

                AdicionarProduto.StartPosition = FormStartPosition.Manual;
                AdicionarProduto.Location = this.Location;

                this.Hide();
                AdicionarProduto.Show();

                AdicionarProduto.FormClosed += (s, args) => this.Show();
            }
            else
            {
                UserList = DataLayer.Load.LoadData(0);
                Cliente cliente = (Cliente)UserList[CurrentUser];

                Form ComprarProduto = new ComprarProduto(CurrentUser);

                ComprarProduto.StartPosition = FormStartPosition.Manual;
                ComprarProduto.Location = this.Location;

                this.Hide();
                ComprarProduto.Show();

                ComprarProduto.FormClosed += (s, args) => this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentUserType == EUserType.Vendedor)
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
                Form AdicionarDinheiro = new AdicionarDinheiro(CurrentUser);

                AdicionarDinheiro.StartPosition = FormStartPosition.Manual;
                AdicionarDinheiro.Location = this.Location;

                this.Hide();
                AdicionarDinheiro.Show();

                AdicionarDinheiro.FormClosed += (s, args) => this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentUserType == EUserType.Vendedor)
            {
                Form AdicionarCampanha = new AdicionarCampanha();

                AdicionarCampanha.StartPosition = FormStartPosition.Manual;
                AdicionarCampanha.Location = this.Location;

                this.Hide();
                AdicionarCampanha.Show();

                AdicionarCampanha.FormClosed += (s, args) => this.Show();
            }
            else
            {
                Form ChecarGarantia = new ChecarGarantia();

                ChecarGarantia.StartPosition = FormStartPosition.Manual;
                ChecarGarantia.Location = this.Location;

                this.Hide();
                ChecarGarantia.Show();

                ChecarGarantia.FormClosed += (s, args) => this.Show();
            }
        }

        private void MostrarMarcasButton_Click(object sender, EventArgs e)
        {
            string str = "";
            int i = 0;

            MarcaList = DataLayer.Load.LoadData(2);

            foreach (DictionaryEntry entry in MarcaList)
            {
                Marca marca = (Marca)MarcaList[entry.Key];
                str += marca.MostrarDados();
                str += "---\n";
                i++;
            }
            MessageBox.Show(str);

            Logging.Log($"Foram mostradas {i} marcas");

        }

        private void MostrarCampanhasButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            string str = "";

            CampanhaList = DataLayer.Load.LoadData(3);
            ProductList = DataLayer.Load.LoadData(1);

            foreach (DictionaryEntry entry in CampanhaList)
            {
                Campanha campanha = (Campanha)CampanhaList[entry.Key];
                str += campanha.MostrarDados(ProductList);
                i++;
            }
            MessageBox.Show(str);
            Logging.Log($"Foram mostradas {i} campanhas");
        }

        private void ApagarDadosButton_Click(object sender, EventArgs e)
        {

        }
    }
}
