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
    public partial class ChecarGarantia : Form
    {
        public ChecarGarantia()
        {
            InitializeComponent();
            Logging.Log("Foi aberto a tela " + this.Name);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChecarButton_Click(object sender, EventArgs e)
        {
            int idproduto = Convert.ToInt32(IDProdutoNumeric.Value);

            Hashtable ProductList = new Hashtable();
            ProductList = DataLayer.Load.LoadData(1);

            Produto produto = (Produto)ProductList[idproduto];
            if (produto == null) 
            {
                MessageBox.Show("Produto não existe");
                return;
            }
            int aux = produto.ChecarGarantia();
            if (aux == 1) MessageBox.Show("Produto está na garantia");
            else MessageBox.Show("Produto não está na garantia");

            Logging.Log("Utilizador checou a garantia de um produto");
        }
    }
}
