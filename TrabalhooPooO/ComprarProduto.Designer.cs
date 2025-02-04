namespace PresentationLayer
{
    partial class ComprarProduto
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
            IDProdutoNumeric = new NumericUpDown();
            ComprarButton = new Button();
            CancelarButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).BeginInit();
            SuspendLayout();
            // 
            // IDProdutoNumeric
            // 
            IDProdutoNumeric.Location = new Point(294, 181);
            IDProdutoNumeric.Name = "IDProdutoNumeric";
            IDProdutoNumeric.Size = new Size(148, 23);
            IDProdutoNumeric.TabIndex = 0;
            // 
            // ComprarButton
            // 
            ComprarButton.Location = new Point(464, 181);
            ComprarButton.Name = "ComprarButton";
            ComprarButton.Size = new Size(75, 23);
            ComprarButton.TabIndex = 1;
            ComprarButton.Text = "Comprar";
            ComprarButton.UseVisualStyleBackColor = true;
            ComprarButton.Click += ComprarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(464, 210);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 2;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 183);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 3;
            label1.Text = "ID do Produto";
            // 
            // ComprarProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(CancelarButton);
            Controls.Add(ComprarButton);
            Controls.Add(IDProdutoNumeric);
            Name = "ComprarProduto";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown IDProdutoNumeric;
        private Button ComprarButton;
        private Button CancelarButton;
        private Label label1;
    }
}