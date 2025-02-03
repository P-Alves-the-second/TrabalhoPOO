namespace TrabalhooPooO
{
    partial class TelaLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LogInButton = new Button();
            RegisterButton = new Button();
            EmailTextBox = new MaskedTextBox();
            SenhaTextBox = new MaskedTextBox();
            NameTextBox = new MaskedTextBox();
            NameLabel = new Label();
            EmailLabel = new Label();
            SenhaLabel = new Label();
            EnterButton1 = new Button();
            ClienteCheckBox = new CheckBox();
            VendedorCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // LogInButton
            // 
            LogInButton.Location = new Point(350, 174);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(75, 23);
            LogInButton.TabIndex = 0;
            LogInButton.Text = "LogIn";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(350, 266);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(75, 23);
            RegisterButton.TabIndex = 1;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(301, 186);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(161, 23);
            EmailTextBox.TabIndex = 2;
            EmailTextBox.Visible = false;
            EmailTextBox.MaskInputRejected += EmailTextBox_MaskInputRejected;
            // 
            // SenhaTextBox
            // 
            SenhaTextBox.Location = new Point(302, 215);
            SenhaTextBox.Name = "SenhaTextBox";
            SenhaTextBox.Size = new Size(160, 23);
            SenhaTextBox.TabIndex = 3;
            SenhaTextBox.Visible = false;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(302, 244);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(160, 23);
            NameTextBox.TabIndex = 4;
            NameTextBox.Visible = false;
            NameTextBox.MaskInputRejected += NameTextBox_MaskInputRejected;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(221, 247);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(45, 15);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Name :";
            NameLabel.Visible = false;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(221, 189);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(42, 15);
            EmailLabel.TabIndex = 6;
            EmailLabel.Text = "Email :";
            EmailLabel.Visible = false;
            EmailLabel.Click += EmailLabel_Click;
            // 
            // SenhaLabel
            // 
            SenhaLabel.AutoSize = true;
            SenhaLabel.Location = new Point(221, 218);
            SenhaLabel.Name = "SenhaLabel";
            SenhaLabel.Size = new Size(45, 15);
            SenhaLabel.TabIndex = 7;
            SenhaLabel.Text = "Senha :";
            SenhaLabel.Visible = false;
            SenhaLabel.Click += label3_Click;
            // 
            // EnterButton1
            // 
            EnterButton1.Location = new Point(350, 295);
            EnterButton1.Name = "EnterButton1";
            EnterButton1.Size = new Size(75, 23);
            EnterButton1.TabIndex = 8;
            EnterButton1.Text = "Enter";
            EnterButton1.UseVisualStyleBackColor = true;
            EnterButton1.Visible = false;
            EnterButton1.Click += button1_Click;
            // 
            // ClienteCheckBox
            // 
            ClienteCheckBox.AutoSize = true;
            ClienteCheckBox.Location = new Point(545, 188);
            ClienteCheckBox.Name = "ClienteCheckBox";
            ClienteCheckBox.Size = new Size(63, 19);
            ClienteCheckBox.TabIndex = 9;
            ClienteCheckBox.Text = "Cliente";
            ClienteCheckBox.UseVisualStyleBackColor = true;
            ClienteCheckBox.Visible = false;
            ClienteCheckBox.CheckedChanged += ClienteCheckBox_CheckedChanged;
            // 
            // VendedorCheckBox
            // 
            VendedorCheckBox.AutoSize = true;
            VendedorCheckBox.Location = new Point(545, 243);
            VendedorCheckBox.Name = "VendedorCheckBox";
            VendedorCheckBox.Size = new Size(76, 19);
            VendedorCheckBox.TabIndex = 10;
            VendedorCheckBox.Text = "Vendedor";
            VendedorCheckBox.UseVisualStyleBackColor = true;
            VendedorCheckBox.Visible = false;
            VendedorCheckBox.CheckedChanged += VendedorCheckBox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(VendedorCheckBox);
            Controls.Add(ClienteCheckBox);
            Controls.Add(EnterButton1);
            Controls.Add(SenhaLabel);
            Controls.Add(EmailLabel);
            Controls.Add(NameLabel);
            Controls.Add(NameTextBox);
            Controls.Add(SenhaTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(RegisterButton);
            Controls.Add(LogInButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LogInButton;
        private Button RegisterButton;
        private MaskedTextBox EmailTextBox;
        private MaskedTextBox SenhaTextBox;
        private MaskedTextBox NameTextBox;
        private Label NameLabel;
        private Label EmailLabel;
        private Label SenhaLabel;
        private Button EnterButton1;
        private CheckBox ClienteCheckBox;
        private CheckBox VendedorCheckBox;
    }
}
