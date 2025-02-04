namespace PresentationLayer
{
    partial class AdicionarCampanha
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
            NameTextBox = new MaskedTextBox();
            DescricaoTextBox = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            ValorTextBox = new CheckBox();
            PorcentagemTextBox = new CheckBox();
            label3 = new Label();
            DescontoNumeric = new NumericUpDown();
            label4 = new Label();
            IDProdutoNumeric = new NumericUpDown();
            label5 = new Label();
            ConfirmarButton = new Button();
            AdicionarButton = new Button();
            CancelarButton = new Button();
            label6 = new Label();
            IDCampanhaNumeric = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)DescontoNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IDCampanhaNumeric).BeginInit();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(281, 119);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(170, 23);
            NameTextBox.TabIndex = 0;
            // 
            // DescricaoTextBox
            // 
            DescricaoTextBox.Location = new Point(281, 148);
            DescricaoTextBox.Name = "DescricaoTextBox";
            DescricaoTextBox.Size = new Size(170, 23);
            DescricaoTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 123);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 156);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Descrição";
            // 
            // ValorTextBox
            // 
            ValorTextBox.AutoSize = true;
            ValorTextBox.Location = new Point(281, 177);
            ValorTextBox.Name = "ValorTextBox";
            ValorTextBox.Size = new Size(52, 19);
            ValorTextBox.TabIndex = 4;
            ValorTextBox.Text = "Valor";
            ValorTextBox.UseVisualStyleBackColor = true;
            ValorTextBox.CheckedChanged += ValorTextBox_CheckedChanged;
            // 
            // PorcentagemTextBox
            // 
            PorcentagemTextBox.AutoSize = true;
            PorcentagemTextBox.Location = new Point(370, 177);
            PorcentagemTextBox.Name = "PorcentagemTextBox";
            PorcentagemTextBox.Size = new Size(97, 19);
            PorcentagemTextBox.TabIndex = 5;
            PorcentagemTextBox.Text = "Porcentagem";
            PorcentagemTextBox.UseVisualStyleBackColor = true;
            PorcentagemTextBox.CheckedChanged += PorcentagemTextBox_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 178);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 6;
            label3.Text = "Tipo de desconto";
            // 
            // DescontoNumeric
            // 
            DescontoNumeric.Location = new Point(281, 202);
            DescontoNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            DescontoNumeric.Name = "DescontoNumeric";
            DescontoNumeric.Size = new Size(170, 23);
            DescontoNumeric.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 250);
            label4.Name = "label4";
            label4.Size = new Size(174, 15);
            label4.TabIndex = 8;
            label4.Text = "Adicionar Produto à Campanha";
            // 
            // IDProdutoNumeric
            // 
            IDProdutoNumeric.Location = new Point(281, 296);
            IDProdutoNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            IDProdutoNumeric.Name = "IDProdutoNumeric";
            IDProdutoNumeric.Size = new Size(172, 23);
            IDProdutoNumeric.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(177, 300);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 10;
            label5.Text = "ID do Produto";
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.Location = new Point(470, 296);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(75, 23);
            ConfirmarButton.TabIndex = 11;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = true;
            ConfirmarButton.Click += ConfirmarButton_Click;
            // 
            // AdicionarButton
            // 
            AdicionarButton.Location = new Point(470, 119);
            AdicionarButton.Name = "AdicionarButton";
            AdicionarButton.Size = new Size(75, 23);
            AdicionarButton.TabIndex = 12;
            AdicionarButton.Text = "Adicionar";
            AdicionarButton.UseVisualStyleBackColor = true;
            AdicionarButton.Click += AdicionarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(470, 151);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 13;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(201, 204);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 14;
            label6.Text = "Desconto";
            // 
            // IDCampanhaNumeric
            // 
            IDCampanhaNumeric.Location = new Point(281, 325);
            IDCampanhaNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            IDCampanhaNumeric.Name = "IDCampanhaNumeric";
            IDCampanhaNumeric.Size = new Size(172, 23);
            IDCampanhaNumeric.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(162, 327);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 16;
            label7.Text = "ID da Campanha";
            // 
            // AdicionarCampanha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(IDCampanhaNumeric);
            Controls.Add(label6);
            Controls.Add(CancelarButton);
            Controls.Add(AdicionarButton);
            Controls.Add(ConfirmarButton);
            Controls.Add(label5);
            Controls.Add(IDProdutoNumeric);
            Controls.Add(label4);
            Controls.Add(DescontoNumeric);
            Controls.Add(label3);
            Controls.Add(PorcentagemTextBox);
            Controls.Add(ValorTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DescricaoTextBox);
            Controls.Add(NameTextBox);
            Name = "AdicionarCampanha";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DescontoNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)IDCampanhaNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox NameTextBox;
        private MaskedTextBox DescricaoTextBox;
        private Label label1;
        private Label label2;
        private CheckBox ValorTextBox;
        private CheckBox PorcentagemTextBox;
        private Label label3;
        private NumericUpDown DescontoNumeric;
        private Label label4;
        private NumericUpDown IDProdutoNumeric;
        private Label label5;
        private Button ConfirmarButton;
        private Button AdicionarButton;
        private Button CancelarButton;
        private Label label6;
        private NumericUpDown IDCampanhaNumeric;
        private Label label7;
    }
}