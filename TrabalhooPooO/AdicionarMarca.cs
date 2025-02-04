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
    public partial class AdicionarMarca : Form
    {

        Hashtable MarcaList = new Hashtable();
        int CurrentMarcaId = 0;
        public AdicionarMarca()
        {
            InitializeComponent();
            Logging.Log("Foi aberto a tela " + this.Name);
        }

        private void CancelarButton_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void CriarButton_Click(object sender, EventArgs e) 
        {
            MarcaList = DataLayer.Load.LoadData(2);
            foreach (DictionaryEntry entry in MarcaList)
            {
                Marca marc = (Marca)MarcaList[entry.Key];
                if (marc.IdMarca >= CurrentMarcaId) CurrentMarcaId = marc.IdMarca + 1;
            }

            string nome = NomeTextBox.Text;

            Marca marcanova = new Marca(nome,CurrentMarcaId);

            MarcaList.Add(marcanova.IdMarca,marcanova);

            Logging.Log("Utilizador adicionou uma marca");

            if (File.Exists("./Marcas.txt")) File.Delete("./Marcas.txt");
            foreach(DictionaryEntry entry in MarcaList) 
            {
                Marca marca = (Marca)MarcaList[entry.Key];
                DataLayer.Save.SaveData(null,null,null,marca,null,2);
            }
            Logging.Log("Marcas foram salvas");
        }
    }
}
