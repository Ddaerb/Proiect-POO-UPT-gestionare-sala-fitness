using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Linq; //folosim metoda All din LINQ impreuna cu functia char.IsDigit pentru a verifica daca un string contine doar cifre
namespace WindowsFormsApp1
{

    public class Validare
    {
        public string ValideazaNume(string input)
        {
            while (string.IsNullOrWhiteSpace(input) || !IsAlphabetic(input))
            {
                MessageBox.Show("Numele trebuie să conțină doar caractere alfabetice.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                input = PromptForInput("Introduceți un nume:");
            }
            return input;
        }

        public int ValideazaNrClienti(string input)
        {
            int rezultat;
            while (!int.TryParse(input, out rezultat) || rezultat < 1 || rezultat > 10)
            {
                MessageBox.Show("Introduceți un număr între 1 și 10.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                input = PromptForInput("Introduceți numărul de clienți:");
            }
            return rezultat;
        }

        public TimeSpan ValideazaOra(string input)
        {
            TimeSpan ora;
            while (!TimeSpan.TryParse(input, out ora))
            {
                MessageBox.Show("Ora nu este într-un format valid (HH:MM:SS).", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                input = PromptForInput("Introduceți ora (HH:MM:SS):");
            }
            return ora;
        }

        public (TimeSpan, TimeSpan) ValideazaInterval(string oraInceputInput, string oraSfarsitInput)
        {
            TimeSpan oraInceput = ValideazaOra(oraInceputInput);
            TimeSpan oraSfarsit = ValideazaOra(oraSfarsitInput);

            while (oraInceput >= oraSfarsit)
            {
                MessageBox.Show("Ora de început trebuie să fie mai mică decât ora de sfârșit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oraInceput = ValideazaOra(PromptForInput("Introduceți ora de început:"));
                oraSfarsit = ValideazaOra(PromptForInput("Introduceți ora de sfârșit:"));
            }
            return (oraInceput, oraSfarsit);
        }

        public string VerificareCNP(string cnp)
        {
            while (!(cnp.Length == 13) || !(cnp.All(char.IsDigit)))
            {
                MessageBox.Show("CNP-ul nu este într-un format valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cnp = PromptForInput("Introduceți un CNP:");
            }
            return cnp;
        }

        public DateTime ValidareData(string dataInput)
        {
            DateTime data;

            while (!DateTime.TryParse(dataInput, out data) || data < DateTime.Now)
            {
                MessageBox.Show("Data nu este într-un format valid sau este în trecut.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataInput = PromptForInput("Introduceți o dată validă (YYYY/MM/DD):");
            }

            return data;
        }

        public string ValideazaNumeComplet(string input)
        {
            while (!IsAlphabetic(input))
            {
                MessageBox.Show("Numele complet trebuie să conțină doar caractere alfabetice.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                input = PromptForInput("Introduceți un nume complet:");
            }
            return input;
        }

        private bool IsAlphabetic(string input)
        {
            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        // Helper function to prompt for input
        private string PromptForInput(string message)
        {
            using (var prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 150;
                prompt.Text = "Input";

                Label textLabel = new Label() { Left = 10, Top = 20, Text = message, Width = 360 };
                TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 360 };
                Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
            }
        }
    }
}