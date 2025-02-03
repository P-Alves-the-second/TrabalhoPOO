using BusinessLayer;
using DataLayer;
using PresentationLayer;
using System.Collections;

namespace TrabalhooPooO
{
    public partial class TelaLogin : Form
    {
        int op = 0;

        public TelaLogin()
        {
            InitializeComponent();
        }
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
        EUserType CurrentUserType = EUserType.Cliente;

        /// <summary>
        /// Listas hash para armazenar usuários, produtos, marcas e campanhas.
        /// </summary>
        Hashtable UserList = new Hashtable();
        Hashtable ProductList = new Hashtable();
        Hashtable MarcaList = new Hashtable();
        Hashtable CampanhaList = new Hashtable();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (op == 1) 
            {
                UserList = DataLayer.Load.LoadData(0);

                EUserType userType = EUserType.Cliente;
                string email = EmailTextBox.Text;
                string senha = SenhaTextBox.Text;
                if (ClienteCheckBox.Checked == true) userType = EUserType.Cliente;
                else if (VendedorCheckBox.Checked == true) userType = EUserType.Vendedor;
                else
                {
                    MessageBox.Show("Escolha um campo");
                    return;
                }
                CurrentUser = BusinessLayer.Extra.LogIn(UserList, email, senha, userType);

                if (CurrentUser == -1) MessageBox.Show("Utilizador não existe");
                else if(CurrentUser == -2) 
                {
                    MessageBox.Show("Senha Incorreta");
                    CurrentUser = -1;
                }
                else 
                {
                    this.Hide();
                    Menu form = new Menu(CurrentUserId,CurrentUser);
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = this.Location;
                    form.Show();
                    form.FormClosed += (s, args) => this.Close();
                }
            }
            else 
            {
                UserList = DataLayer.Load.LoadData(0);

                foreach (DictionaryEntry entry in UserList)
                {
                    User user = (User)UserList[entry.Key];
                    if (user.IdUser >= CurrentUserId) CurrentUserId = user.IdUser + 1;
                }

                string email = EmailTextBox.Text;
                string senha = SenhaTextBox.Text;
                string nome = NameTextBox.Text;
                if (ClienteCheckBox.Checked == true) 
                {
                    Cliente user = new Cliente(nome,email,senha,CurrentUserId);
                    UserList = user.Register(UserList);
                    ClienteCheckBox.Checked = false;
                }
                else if (VendedorCheckBox.Checked == true) 
                {
                    Vendedor user = new Vendedor(nome, email, senha, CurrentUserId);
                    UserList = user.Register(UserList);
                    VendedorCheckBox.Checked = false;
                }
                else
                {
                    MessageBox.Show("Escolha um campo");
                    return;
                }

                if (File.Exists("./Users.txt")) File.Delete("./Users.txt");
                foreach (DictionaryEntry entry in UserList)
                {
                    User user = (User)UserList[entry.Key];
                    DataLayer.Save.SaveData(user,null,null,0);
                }

                LogInButton.Visible = true;
                RegisterButton.Visible = true;
                EnterButton1.Visible = false;

                EmailTextBox.Visible = false;
                SenhaTextBox.Visible = false;
                NameTextBox.Visible = false;

                EmailLabel.Visible = false;
                SenhaLabel.Visible = false;
                NameLabel.Visible = false;

                ClienteCheckBox.Visible = false;
                VendedorCheckBox.Visible = false;

                EmailTextBox.Text = "";
                SenhaTextBox.Text = "";
                NameTextBox.Text = "";
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            LogInButton.Visible = false;
            RegisterButton.Visible = false;
            EnterButton1.Visible = true;

            EmailTextBox.Visible = true;
            SenhaTextBox.Visible = true;

            EmailLabel.Visible = true;
            SenhaLabel.Visible = true;

            ClienteCheckBox.Visible = true;
            VendedorCheckBox.Visible = true;

            op = 1;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            LogInButton.Visible = false;
            RegisterButton.Visible = false;
            EnterButton1.Visible = true;

            EmailTextBox.Visible = true;
            SenhaTextBox.Visible = true;
            NameTextBox.Visible = true;

            EmailLabel.Visible = true;
            SenhaLabel.Visible = true;
            NameLabel.Visible = true;

            ClienteCheckBox.Visible = true;
            VendedorCheckBox.Visible = true;

            op = 2;
        }

        private void NameTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EmailTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClienteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ClienteCheckBox.Checked==true)VendedorCheckBox.Checked = false;
            
        }

        private void VendedorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(VendedorCheckBox.Checked==true)ClienteCheckBox.Checked = false;
            
        }
    }
}
