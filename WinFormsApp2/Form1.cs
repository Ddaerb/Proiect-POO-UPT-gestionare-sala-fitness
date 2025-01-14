using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;

        public Form1(AbonatManager abonatManager, IServiceProvider serviceProvider)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }


        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string usernameAdmin = "admin";
            string passwordAdmin = "admin";

            if (username == null || username == "")
            {
                MessageBox.Show("Campul pentru numele de utilizator trebuie completat");
                Log.Error("Campul pentru numele de utilizator trebuie completat."); 
                return;
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Campul pentru parola trebuie completat");
                Log.Error("Campul pentru parola trebuie completat.");
                return;
            }

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Buna ziua, admin");
                Log.Information("Autentificare cu succes pentru admin.");
                this.Hide();
                var adminForm = _serviceProvider.GetRequiredService<ContAdmin>();
                adminForm.Show();
                return;
            }


            AbonatStandard abonat = _abonatManager.GasesteAbonatDupaUsername(username);
            if (abonat == null || abonat.Password != password)
            {
                MessageBox.Show("Nume de utilizator sau parola incorecte, incercati din nou");
                Log.Error("Nume de utilizator sau parola incorecte.");
                return;
            }

            MessageBox.Show($"Buna ziua, {abonat.NumeComplet}");
            Log.Information("Autentificare cu succes pentru abonat.");
            this.Hide();

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.InitializeUser(abonat);
            contAbonat.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.ShowRegisterForm();
        }

        private void ShowRegisterForm()
        {
            this.Hide();
            var registerForm = _serviceProvider.GetRequiredService<RegisterForm>();
            registerForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.Information("Form1 (Login) incarcata cu succes.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            var paginaPrincipala = _serviceProvider.GetRequiredService<PaginaPrincipala>();
            paginaPrincipala.Show();
        }
    }
}
