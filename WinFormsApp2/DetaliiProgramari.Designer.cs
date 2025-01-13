namespace WinFormsApp2
{
    partial class DetaliiProgramari
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSlateBlue;
            button1.Font = new Font("Century", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(54, 49);
            button1.Name = "button1";
            button1.Size = new Size(192, 43);
            button1.TabIndex = 0;
            button1.Text = "Adauga Programare";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.CornflowerBlue;
            button2.Font = new Font("Century", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(54, 312);
            button2.Name = "button2";
            button2.Size = new Size(115, 38);
            button2.TabIndex = 14;
            button2.Text = "Inapoi";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(220, 384);
            label1.Name = "label1";
            label1.Size = new Size(530, 46);
            label1.TabIndex = 15;
            label1.Text = "Daca depasiti orele [din cod], se adauga o \r\n                              taxa de penalizare de x RON/ora!!!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(54, 384);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 16;
            label2.Text = "ATENTIE!";
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Font = new Font("Century", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(54, 206);
            button3.Name = "button3";
            button3.Size = new Size(192, 43);
            button3.TabIndex = 17;
            button3.Text = "Anuleaza Programare";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Orchid;
            button4.Font = new Font("Century", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(54, 126);
            button4.Name = "button4";
            button4.Size = new Size(192, 43);
            button4.TabIndex = 18;
            button4.Text = "Modifica Programare";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(339, 49);
            listView1.Name = "listView1";
            listView1.Size = new Size(411, 301);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DetaliiProgramari
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "DetaliiProgramari";
            Text = "DetaliiProgramari";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Button button3;
        private Button button4;
        private ListView listView1;
    }
}