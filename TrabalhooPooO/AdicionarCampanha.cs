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
    public partial class AdicionarCampanha : Form
    {
        public AdicionarCampanha()
        {
            InitializeComponent();
            Logging.Log("Foi aberto a tela " + this.Name);
        }

        private void ValorTextBox_CheckedChanged(object sender, EventArgs e) 
        {
            if (ValorTextBox.Checked == true) PorcentagemTextBox.Checked = false;
        }

        private void PorcentagemTextBox_CheckedChanged(object sender, EventArgs e) 
        {
            if (PorcentagemTextBox.Checked==true) ValorTextBox.Checked = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void AdicionarButton_Click(object sender, EventArgs e) 
        {
            string nome = NameTextBox.Text;
            string descricao = DescricaoTextBox.Text;
            DescontoType descontotype = DescontoType.valor;
            double desconto = Convert.ToDouble(DescontoNumeric.Value);
            int CurrentCampanhaID = 0;

            if (PorcentagemTextBox.Checked == true) descontotype = DescontoType.porcentagem;
            else if (ValorTextBox.Checked == true) descontotype = DescontoType.valor;
            else MessageBox.Show("Escolha um Campo");

            Hashtable CampanhaList = new Hashtable();
            Hashtable UserList = new Hashtable();
            UserList = DataLayer.Load.LoadData(0);
            CampanhaList = DataLayer.Load.LoadData(3);

            foreach (DictionaryEntry entry in CampanhaList) 
            {
                Campanha aux = (Campanha)CampanhaList[entry.Key];
                if (aux.CampanhaId >= CurrentCampanhaID) CurrentCampanhaID = aux.CampanhaId + 1;
            }

            Campanha campanha = new Campanha(CurrentCampanhaID, nome, descricao, desconto, descontotype);
            MessageBox.Show($"{desconto}");
            CampanhaList.Add(campanha.CampanhaId,campanha);

            Logging.Log("Utilizador adicionou uma campanha");

            if (File.Exists("./Campanhas.txt")) File.Delete("./Campanhas.txt");
            foreach(DictionaryEntry entry in CampanhaList) 
            {
                Campanha aux2 = (Campanha)CampanhaList[entry.Key];
                DataLayer.Save.SaveData(null,null,null,null,aux2,3);
            }
            Logging.Log("Campanhas foram salvas");

        }
        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            int prouctid = Convert.ToInt32(IDProdutoNumeric.Value);
            int campanhaid = Convert.ToInt32(IDCampanhaNumeric.Value);

            Hashtable ProductList = new Hashtable();
            Hashtable CampanhaList = new Hashtable();
            ProductList = DataLayer.Load.LoadData(1);
            CampanhaList = DataLayer.Load.LoadData(3);
            if (CampanhaList != null) 
            {
                Campanha campanha = (Campanha)CampanhaList[campanhaid];
                int aux = campanha.AdicionarProduto(ProductList, prouctid);
                string str = "";

                if (aux == 1) str = "Produto ja pertence a uma campanha";
                else if (aux == 2) str = "Produto ja pertence a essa campanha";
                else
                {
                    str = "Produto adicionado";
                    Logging.Log("Utilizador adicionou um produto à uma campanha");
                }

                MessageBox.Show(str);

                if (File.Exists("./Campanhas.txt")) File.Delete("./Campanhas.txt");
                foreach (DictionaryEntry entry in CampanhaList)
                {
                    Campanha aux2 = (Campanha)CampanhaList[entry.Key];
                    DataLayer.Save.SaveData(null, null, null, null, aux2, 3);
                }
                Logging.Log("Campanhas foram salvas");

            }
        }

    }
}
