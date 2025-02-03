namespace PresentationLayer
{
    partial class AdicionarMarca
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
            label1 = new Label();
            NomeTextBox = new MaskedTextBox();
            CriarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(237, 177);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // NomeTextBox
            // 
            NomeTextBox.Location = new Point(292, 174);
            NomeTextBox.Name = "NomeTextBox";
            NomeTextBox.Size = new Size(174, 23);
            NomeTextBox.TabIndex = 1;
            // 
            // CriarButton
            // 
            CriarButton.Location = new Point(516, 174);
            CriarButton.Name = "CriarButton";
            CriarButton.Size = new Size(75, 23);
            CriarButton.TabIndex = 2;
            CriarButton.Text = "Criar";
            CriarButton.UseVisualStyleBackColor = true;
            CriarButton.Click += this.CriarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(516, 203);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // AdicionarMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelarButton);
            Controls.Add(CriarButton);
            Controls.Add(NomeTextBox);
            Controls.Add(label1);
            Name = "AdicionarMarca";
            Text = "Adicionar Marca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaskedTextBox NomeTextBox;
        private Button CriarButton;
        private Button CancelarButton;
    }
}