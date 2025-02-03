namespace PresentationLayer
{
    partial class AdicionarProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NomeTextBox = new MaskedTextBox();
            DescricaoTextBox = new MaskedTextBox();
            NomeLabel = new Label();
            DescricaoLabel = new Label();
            PrecoNumeric = new NumericUpDown();
            MarcaIDNumeric = new NumericUpDown();
            GarantiaNumeric = new NumericUpDown();
            comboBox1 = new ComboBox();
            CategoriaComboBox = new ComboBox();
            PrecoLabel = new Label();
            MarcaIDLabel = new Label();
            GarantiaLabel = new Label();
            TipoGarantiaComboBox = new Label();
            CategoriaLabel = new Label();
            AdicionarButton = new Button();
            CancelarButton = new Button();
            StockNumeric = new NumericUpDown();
            StockLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)PrecoNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MarcaIDNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GarantiaNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StockNumeric).BeginInit();
            SuspendLayout();
            // 
            // NomeTextBox
            // 
            NomeTextBox.Location = new Point(292, 123);
            NomeTextBox.Name = "NomeTextBox";
            NomeTextBox.Size = new Size(150, 23);
            NomeTextBox.TabIndex = 0;
            // 
            // DescricaoTextBox
            // 
            DescricaoTextBox.Location = new Point(292, 152);
            DescricaoTextBox.Name = "DescricaoTextBox";
            DescricaoTextBox.Size = new Size(150, 23);
            DescricaoTextBox.TabIndex = 1;
            // 
            // NomeLabel
            // 
            NomeLabel.AutoSize = true;
            NomeLabel.Location = new Point(182, 126);
            NomeLabel.Name = "NomeLabel";
            NomeLabel.Size = new Size(40, 15);
            NomeLabel.TabIndex = 2;
            NomeLabel.Text = "Nome";
            // 
            // DescricaoLabel
            // 
            DescricaoLabel.AutoSize = true;
            DescricaoLabel.Location = new Point(182, 155);
            DescricaoLabel.Name = "DescricaoLabel";
            DescricaoLabel.Size = new Size(58, 15);
            DescricaoLabel.TabIndex = 3;
            DescricaoLabel.Text = "Descrição";
            // 
            // PrecoNumeric
            // 
            PrecoNumeric.Location = new Point(292, 181);
            PrecoNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            PrecoNumeric.Name = "PrecoNumeric";
            PrecoNumeric.Size = new Size(150, 23);
            PrecoNumeric.TabIndex = 4;
            // 
            // MarcaIDNumeric
            // 
            MarcaIDNumeric.Location = new Point(292, 210);
            MarcaIDNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            MarcaIDNumeric.Name = "MarcaIDNumeric";
            MarcaIDNumeric.Size = new Size(150, 23);
            MarcaIDNumeric.TabIndex = 5;
            // 
            // GarantiaNumeric
            // 
            GarantiaNumeric.Location = new Point(292, 268);
            GarantiaNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            GarantiaNumeric.Name = "GarantiaNumeric";
            GarantiaNumeric.Size = new Size(150, 23);
            GarantiaNumeric.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dias", "Meses", "Anos" });
            comboBox1.Location = new Point(292, 297);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 23);
            comboBox1.TabIndex = 7;
            // 
            // CategoriaComboBox
            // 
            CategoriaComboBox.FormattingEnabled = true;
            CategoriaComboBox.Items.AddRange(new object[] { "Roupas", "Sapatos", "Utensilios", "Eletronicos" });
            CategoriaComboBox.Location = new Point(292, 326);
            CategoriaComboBox.Name = "CategoriaComboBox";
            CategoriaComboBox.Size = new Size(150, 23);
            CategoriaComboBox.TabIndex = 8;
            // 
            // PrecoLabel
            // 
            PrecoLabel.AutoSize = true;
            PrecoLabel.Location = new Point(182, 183);
            PrecoLabel.Name = "PrecoLabel";
            PrecoLabel.Size = new Size(37, 15);
            PrecoLabel.TabIndex = 9;
            PrecoLabel.Text = "Preço";
            // 
            // MarcaIDLabel
            // 
            MarcaIDLabel.AutoSize = true;
            MarcaIDLabel.Location = new Point(182, 212);
            MarcaIDLabel.Name = "MarcaIDLabel";
            MarcaIDLabel.Size = new Size(70, 15);
            MarcaIDLabel.TabIndex = 10;
            MarcaIDLabel.Text = "ID da Marca";
            // 
            // GarantiaLabel
            // 
            GarantiaLabel.AutoSize = true;
            GarantiaLabel.Location = new Point(182, 270);
            GarantiaLabel.Name = "GarantiaLabel";
            GarantiaLabel.Size = new Size(51, 15);
            GarantiaLabel.TabIndex = 11;
            GarantiaLabel.Text = "Garantia";
            // 
            // TipoGarantiaComboBox
            // 
            TipoGarantiaComboBox.AutoSize = true;
            TipoGarantiaComboBox.Location = new Point(182, 300);
            TipoGarantiaComboBox.Name = "TipoGarantiaComboBox";
            TipoGarantiaComboBox.Size = new Size(93, 15);
            TipoGarantiaComboBox.TabIndex = 12;
            TipoGarantiaComboBox.Text = "Tipo da Garantia";
            // 
            // CategoriaLabel
            // 
            CategoriaLabel.AutoSize = true;
            CategoriaLabel.Location = new Point(182, 329);
            CategoriaLabel.Name = "CategoriaLabel";
            CategoriaLabel.Size = new Size(58, 15);
            CategoriaLabel.TabIndex = 13;
            CategoriaLabel.Text = "Categoria";
            // 
            // AdicionarButton
            // 
            AdicionarButton.Location = new Point(558, 183);
            AdicionarButton.Name = "AdicionarButton";
            AdicionarButton.Size = new Size(75, 23);
            AdicionarButton.TabIndex = 14;
            AdicionarButton.Text = "Adicionar";
            AdicionarButton.UseVisualStyleBackColor = true;
            AdicionarButton.Click += AdicionarButton_Click_1;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(558, 237);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 15;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click_1;
            // 
            // StockNumeric
            // 
            StockNumeric.Location = new Point(292, 239);
            StockNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            StockNumeric.Name = "StockNumeric";
            StockNumeric.Size = new Size(150, 23);
            StockNumeric.TabIndex = 16;
            // 
            // StockLabel
            // 
            StockLabel.AutoSize = true;
            StockLabel.Location = new Point(182, 241);
            StockLabel.Name = "StockLabel";
            StockLabel.Size = new Size(49, 15);
            StockLabel.TabIndex = 17;
            StockLabel.Text = "Estoque";
            // 
            // AdicionarProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StockLabel);
            Controls.Add(StockNumeric);
            Controls.Add(CancelarButton);
            Controls.Add(AdicionarButton);
            Controls.Add(CategoriaLabel);
            Controls.Add(TipoGarantiaComboBox);
            Controls.Add(GarantiaLabel);
            Controls.Add(MarcaIDLabel);
            Controls.Add(PrecoLabel);
            Controls.Add(CategoriaComboBox);
            Controls.Add(comboBox1);
            Controls.Add(GarantiaNumeric);
            Controls.Add(MarcaIDNumeric);
            Controls.Add(PrecoNumeric);
            Controls.Add(DescricaoLabel);
            Controls.Add(NomeLabel);
            Controls.Add(DescricaoTextBox);
            Controls.Add(NomeTextBox);
            Name = "AdicionarProduto";
            Text = "Adicionar Produto";
            ((System.ComponentModel.ISupportInitialize)PrecoNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)MarcaIDNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)GarantiaNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)StockNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox NomeTextBox;
        private MaskedTextBox DescricaoTextBox;
        private Label NomeLabel;
        private Label DescricaoLabel;
        private NumericUpDown PrecoNumeric;
        private NumericUpDown MarcaIDNumeric;
        private NumericUpDown GarantiaNumeric;
        private ComboBox comboBox1;
        private ComboBox CategoriaComboBox;
        private Label PrecoLabel;
        private Label MarcaIDLabel;
        private Label GarantiaLabel;
        private Label TipoGarantiaComboBox;
        private Label CategoriaLabel;
        private Button AdicionarButton;
        private Button CancelarButton;
        private NumericUpDown StockNumeric;
        private Label StockLabel;
    }
}