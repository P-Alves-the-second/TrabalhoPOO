namespace PresentationLayer
{
    partial class AdicionarDinheiro
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
            QuantidadeNumeric = new NumericUpDown();
            QuantidadeLabel = new Label();
            AdicionarButton = new Button();
            CancelarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)QuantidadeNumeric).BeginInit();
            SuspendLayout();
            // 
            // QuantidadeNumeric
            // 
            QuantidadeNumeric.Location = new Point(319, 187);
            QuantidadeNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            QuantidadeNumeric.Name = "QuantidadeNumeric";
            QuantidadeNumeric.Size = new Size(120, 23);
            QuantidadeNumeric.TabIndex = 0;
            // 
            // QuantidadeLabel
            // 
            QuantidadeLabel.AutoSize = true;
            QuantidadeLabel.Location = new Point(227, 189);
            QuantidadeLabel.Name = "QuantidadeLabel";
            QuantidadeLabel.Size = new Size(69, 15);
            QuantidadeLabel.TabIndex = 1;
            QuantidadeLabel.Text = "Quantidade";
            // 
            // AdicionarButton
            // 
            AdicionarButton.Location = new Point(489, 185);
            AdicionarButton.Name = "AdicionarButton";
            AdicionarButton.Size = new Size(75, 23);
            AdicionarButton.TabIndex = 2;
            AdicionarButton.Text = "Adicionar";
            AdicionarButton.UseVisualStyleBackColor = true;
            AdicionarButton.Click += AdicionarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(489, 214);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // AdicionarDinheiro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelarButton);
            Controls.Add(AdicionarButton);
            Controls.Add(QuantidadeLabel);
            Controls.Add(QuantidadeNumeric);
            Name = "AdicionarDinheiro";
            Text = "Adicionar Dinheiro";
            ((System.ComponentModel.ISupportInitialize)QuantidadeNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown QuantidadeNumeric;
        private Label QuantidadeLabel;
        private Button AdicionarButton;
        private Button CancelarButton;
    }
}