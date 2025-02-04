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
    public partial class AdicionarDinheiro : Form
    {
        int CurrentUser = -2;
        Hashtable UserList = new Hashtable();
        public AdicionarDinheiro(int currentuser)
        {
            InitializeComponent();
            CurrentUser = currentuser;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarButton_Click(object sender, EventArgs e) 
        {
            double quantidade = Convert.ToDouble(QuantidadeNumeric.Value);
            UserList = DataLayer.Load.LoadData(0);
            Cliente user = (Cliente)UserList[CurrentUser];

            user.addCash(quantidade);

            MessageBox.Show($"Sucesso");

            Logging.Log($"Utilizador adicionou {quantidade}$ de saldo");

            if (File.Exists("./Users.txt")) File.Delete("./Users.txt");
            foreach(DictionaryEntry entry in UserList) 
            {
                User utilizador = (User)UserList[entry.Key];
                DataLayer.Save.SaveData(UserList,utilizador,null,null,null,0);
            }
            Logging.Log("Utilizadores foram salvos");
        }
    }
}
