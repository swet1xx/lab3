using System;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        private PalindromeChecker checker = new PalindromeChecker();

        public Form1()
        {
            InitializeComponent();
            SetupButtons();
        }

        private void SetupButtons()
        {
            // Налаштування текстів кнопок
            button1.Text = "Перевірити";
            button2.Text = "Очистити";

            // Підписка на події
            button1.Click += CheckPalindrome;
            button2.Click += ClearFields;
            textBox1.KeyPress += TextBox1_KeyPress;
        }

        private void CheckPalindrome(object? sender, EventArgs e)
        {
            try
            {
                string input = textBox1.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Будь ласка, введіть слово для перевірки!", "Помилка");
                    return;
                }

                bool isPalindrome = checker.IsPalindrome(input);

                // Очищаємо treeView та додаємо результат
                treeView1.Nodes.Clear();

                if (isPalindrome)
                {
                    treeView1.Nodes.Add("✅ Результат: Це паліндром!");
                    treeView1.Nodes[0].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    treeView1.Nodes.Add("❌ Результат: Це не паліндром");
                    treeView1.Nodes[0].ForeColor = System.Drawing.Color.Red;
                }

                // Додаємо інформацію про оброблене слово
                treeView1.Nodes.Add($"Оброблене слово: {checker.GetNormalizedString(input)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            textBox1.Clear();
            treeView1.Nodes.Clear();
        }

        private void TextBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckPalindrome(sender, e);
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Цей метод можна залишити порожнім або видалити
        }
    }
}