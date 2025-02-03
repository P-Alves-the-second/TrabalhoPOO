using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AdicionarProduto : Form
    {
        int CurrentUser = -1;
        int CurrentProductID = -1;
        Hashtable Lista = new Hashtable();
        public AdicionarProduto(Hashtable MarcaList,int currentuser)
        {
            InitializeComponent();
            Lista = MarcaList;
            CurrentUser = currentuser;
        }

        private void CancelarButton_Click_1(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void AdicionarButton_Click_1(object sender, EventArgs e) 
        {
            Hashtable ProductList = new Hashtable();
            ProductList = DataLayer.Load.LoadData(1);

            int MarcaID = Convert.ToInt32(MarcaIDNumeric.Value);
            double price = Convert.ToDouble(PrecoNumeric.Value);
            int stock = Convert.ToInt32(StockNumeric.Value);
            int garantia = Convert.ToInt32(GarantiaNumeric.Value);

            string text = CategoriaComboBox.Text;
            CategoriaProduto categoria = CategoriaProduto.sapatos;

            switch (text) 
            {
                case "Roupas":
                    categoria = CategoriaProduto.roupas;
                    break;
                case "Sapatos":
                    categoria = CategoriaProduto.sapatos;
                    break;
                case "Utensilios":
                    categoria = CategoriaProduto.utensilios;
                    break;
                case "Eletronicos":
                    categoria = CategoriaProduto.eletronicos;
                    break;
            }

            text = TipoGarantiaComboBox.Text;
            GarantiaType TipoGarantia = GarantiaType.Dia;

            switch (text) 
            {
                case "Dias":
                    TipoGarantia = GarantiaType.Dia;
                    break;
                case "Meses":
                    TipoGarantia = GarantiaType.Mes;
                    break;
                case "Anos":
                    TipoGarantia = GarantiaType.Ano;
                    break;
            }

            string nome = NomeTextBox.Text;
            string descricao = DescricaoTextBox.Text;

            if (ProductList != null) foreach (DictionaryEntry entry in ProductList)
                {
                    Produto produt = (Produto)ProductList[entry.Key];
                    if (produt.ProductId >= CurrentProductID) CurrentProductID = produt.ProductId + 1;
                }

            Produto produto = new Produto(CurrentUser,CurrentProductID,MarcaID,price,nome,descricao,stock,categoria,garantia,TipoGarantia);
            ProductList.Add(produto.ProductId,produto);

            if (File.Exists("./Produtos.txt")) File.Delete("./Produtos.txt");
            foreach(DictionaryEntry entry in ProductList) 
            {
                Produto produtosave = (Produto)ProductList[entry.Key];
                DataLayer.Save.SaveData(null,produtosave,null,1);
            }

        }
    }
}
