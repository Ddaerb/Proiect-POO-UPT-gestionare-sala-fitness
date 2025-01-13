namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == null || username == "")
            {
                MessageBox.Show("Campul pentru numele de utilizator trebuie completat");
                return;
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Campul pentru parola trebuie completat");
                return;
            }

            AbonatManager abonatManager = new AbonatManager();
            AbonatStandard abonat = abonatManager.GasesteAbonatDupaUsername(username);
            if (abonat == null || abonat.Password != password)
            {
                MessageBox.Show("Nume de utilizator sau parola incorecte, incercati din nou");
                return;
            }
            MessageBox.Show($"Buna ziua, {abonat.NumeComplet}");
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.ShowRegisterForm();
        }

        private void ShowRegisterForm()
        {
            this.Hide();

            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
