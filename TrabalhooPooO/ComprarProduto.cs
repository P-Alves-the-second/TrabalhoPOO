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

namespace PresentationLayer
{
    public partial class ComprarProduto : Form
    {
        int CurrentUser = -2;
        public ComprarProduto(int currentuser)
        {
            InitializeComponent();
            CurrentUser = currentuser;
            Logging.Log("Foi aberto o tela " + this.Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void ComprarButton_Click(object sender, EventArgs e) 
        {
            int produtoid = Convert.ToInt32(IDProdutoNumeric.Value);

            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();
            Hashtable CampanhaList = new Hashtable();

            UserList = DataLayer.Load.LoadData(0);
            ProductList = DataLayer.Load.LoadData(1);
            CampanhaList = DataLayer.Load.LoadData(3);

            Produto produto = (Produto)ProductList[produtoid];
            if (produto == null) 
            {
                MessageBox.Show("Produto não existe");
                return;
            }
            Cliente cliente = (Cliente)UserList[CurrentUser];
            int i = cliente.Buy(ProductList,UserList,CampanhaList,produtoid);
            if (i == 2) MessageBox.Show("Estoque insuficiente");
            else if (i == 3) MessageBox.Show("Saldo Insuficiente");
            else
            {
                MessageBox.Show("Sucesso");
                Logging.Log("Utilizador comprou um produto");
            }
            if (File.Exists("./Users.txt")) File.Delete("./Users.txt");
            foreach(DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                DataLayer.Save.SaveData(UserList,user,null,null,null,0);
            }
            Logging.Log("Utilizadores foram salvos");
        }

    }
}
