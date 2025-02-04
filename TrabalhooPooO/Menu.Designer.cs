namespace PresentationLayer
{
    partial class Menu
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
            Button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            MostrarMarcasButton = new Button();
            MostrarCampanhasButton = new Button();
            SignOutButton = new Button();
            ApagarDadosButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Button1
            // 
            Button1.Location = new Point(322, 119);
            Button1.Name = "Button1";
            Button1.Size = new Size(124, 23);
            Button1.TabIndex = 2;
            Button1.Text = "Mostrar Produtos";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(322, 148);
            button2.Name = "button2";
            button2.Size = new Size(124, 23);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(322, 177);
            button3.Name = "button3";
            button3.Size = new Size(124, 23);
            button3.TabIndex = 4;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(322, 206);
            button4.Name = "button4";
            button4.Size = new Size(124, 23);
            button4.TabIndex = 5;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // MostrarMarcasButton
            // 
            MostrarMarcasButton.Location = new Point(322, 235);
            MostrarMarcasButton.Name = "MostrarMarcasButton";
            MostrarMarcasButton.Size = new Size(124, 23);
            MostrarMarcasButton.TabIndex = 6;
            MostrarMarcasButton.Text = "Mostrar Marcas";
            MostrarMarcasButton.UseVisualStyleBackColor = true;
            MostrarMarcasButton.Click += MostrarMarcasButton_Click;
            // 
            // MostrarCampanhasButton
            // 
            MostrarCampanhasButton.Location = new Point(322, 264);
            MostrarCampanhasButton.Name = "MostrarCampanhasButton";
            MostrarCampanhasButton.Size = new Size(124, 23);
            MostrarCampanhasButton.TabIndex = 7;
            MostrarCampanhasButton.Text = "Mostrar Campanhas";
            MostrarCampanhasButton.UseVisualStyleBackColor = true;
            MostrarCampanhasButton.Click += MostrarCampanhasButton_Click;
            // 
            // SignOutButton
            // 
            SignOutButton.Location = new Point(322, 360);
            SignOutButton.Name = "SignOutButton";
            SignOutButton.Size = new Size(124, 23);
            SignOutButton.TabIndex = 8;
            SignOutButton.Text = "Sign Out";
            SignOutButton.UseVisualStyleBackColor = true;
            SignOutButton.Click += SignOutButton_Click;
            // 
            // ApagarDadosButton
            // 
            ApagarDadosButton.Location = new Point(322, 402);
            ApagarDadosButton.Name = "ApagarDadosButton";
            ApagarDadosButton.Size = new Size(124, 23);
            ApagarDadosButton.TabIndex = 9;
            ApagarDadosButton.Text = "Apagar Dados";
            ApagarDadosButton.UseVisualStyleBackColor = true;
            ApagarDadosButton.Click += ApagarDadosButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ApagarDadosButton);
            Controls.Add(SignOutButton);
            Controls.Add(MostrarCampanhasButton);
            Controls.Add(MostrarMarcasButton);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Button1);
            Controls.Add(label1);
            Name = "Menu";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button MostrarMarcasButton;
        private Button MostrarCampanhasButton;
        private Button SignOutButton;
        private Button ApagarDadosButton;
    }
}