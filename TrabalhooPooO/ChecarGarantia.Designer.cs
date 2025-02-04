namespace PresentationLayer
{
    partial class ChecarGarantia
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
            label1 = new Label();
            ChecarButton = new Button();
            CancelarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).BeginInit();
            SuspendLayout();
            // 
            // IDProdutoNumeric
            // 
            IDProdutoNumeric.Location = new Point(281, 173);
            IDProdutoNumeric.Name = "IDProdutoNumeric";
            IDProdutoNumeric.Size = new Size(177, 23);
            IDProdutoNumeric.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(194, 175);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "ID do Produto";
            // 
            // ChecarButton
            // 
            ChecarButton.Location = new Point(464, 173);
            ChecarButton.Name = "ChecarButton";
            ChecarButton.Size = new Size(75, 23);
            ChecarButton.TabIndex = 2;
            ChecarButton.Text = "Checar";
            ChecarButton.UseVisualStyleBackColor = true;
            ChecarButton.Click += ChecarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(464, 202);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // ChecarGarantia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelarButton);
            Controls.Add(ChecarButton);
            Controls.Add(label1);
            Controls.Add(IDProdutoNumeric);
            Name = "ChecarGarantia";
            Text = "ChecarGarantia";
            ((System.ComponentModel.ISupportInitialize)IDProdutoNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown IDProdutoNumeric;
        private Label label1;
        private Button ChecarButton;
        private Button CancelarButton;
    }
}