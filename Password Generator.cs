using System.Text;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        private static readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private static string GenerateRandomPassword(int length)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }

        private void GenerateAndDisplayPassword(int length)
        {
            string password = GenerateRandomPassword(length);
            textBox1.Text = password;
            listBox1.Items.Add(password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateAndDisplayPassword(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating password: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (listBox1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a password to copy to the clipboard.", "Error");
                    return; // Exit the method if nothing is selected
                }


                StringBuilder sb = new StringBuilder();

                foreach (object row in listBox1.SelectedItems)
                {
                    sb.AppendLine(row.ToString());
                }

                Clipboard.SetData(DataFormats.Text, sb.ToString().TrimEnd());
                MessageBox.Show("Copied to clipboard: " + sb.ToString(), "Password Generator");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying to clipboard: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The random password generator application was coded by Hasan Hüseyin KARAKAYA.", "Thank you for using it :D");
        }
    }
}
