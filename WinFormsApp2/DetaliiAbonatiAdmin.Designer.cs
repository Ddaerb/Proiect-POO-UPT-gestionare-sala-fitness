namespace WinFormsApp2
{
    partial class DetaliiAbonatiAdmin
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
            button3 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Navy;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(39, 362);
            button3.Name = "button3";
            button3.Size = new Size(105, 46);
            button3.TabIndex = 7;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumVioletRed;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(39, 24);
            button2.Name = "button2";
            button2.Size = new Size(181, 41);
            button2.TabIndex = 6;
            button2.Text = "Sterge Abonat";
            button2.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            listView1.Location = new Point(251, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(510, 402);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DetaliiAbonatiAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Name = "DetaliiAbonatiAdmin";
            Text = "DetaliiAbonatiAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button2;
        private ListView listView1;
    }
}