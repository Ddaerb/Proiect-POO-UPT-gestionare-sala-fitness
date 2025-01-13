namespace WinFormsApp2
{
    partial class Form1
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
            Username = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            LoginButton = new Button();
            label2 = new Label();
            RegisterButton = new Button();
            SuspendLayout();
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.Location = new Point(324, 72);
            Username.Name = "Username";
            Username.Size = new Size(99, 28);
            Username.TabIndex = 0;
            Username.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(331, 114);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(331, 203);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(324, 161);
            label1.Name = "label1";
            label1.Size = new Size(93, 28);
            label1.TabIndex = 2;
            label1.Text = "Password";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.Navy;
            LoginButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = SystemColors.ButtonHighlight;
            LoginButton.Location = new Point(331, 279);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(109, 41);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(324, 335);
            label2.Name = "label2";
            label2.Size = new Size(143, 17);
            label2.TabIndex = 5;
            label2.Text = "Don't have an account?";
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.Navy;
            RegisterButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = SystemColors.ButtonHighlight;
            RegisterButton.Location = new Point(345, 355);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(78, 37);
            RegisterButton.TabIndex = 6;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterButton);
            Controls.Add(label2);
            Controls.Add(LoginButton);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(Username);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Username;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Button LoginButton;
        private Label label2;
        private Button RegisterButton;
    }
}
