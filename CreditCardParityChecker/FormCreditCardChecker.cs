using System;
using System.IO;
using System.Windows.Forms;

namespace CreditCardParityChecker
{
    public partial class FormCreditCardChecker : Form
    {
        public FormCreditCardChecker()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\credit.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    TxtResult.Text += CheckCard(line) + Environment.NewLine;
                }
            }
        }

        private string CheckCard(string input)
        {
            int evenDigit = 0;
            int oddDigit = 0;
            int doubled = 0;
            int sumDoubledEvenDigits = 0;
            int sumOddDigits = 0;
            int totalSum = 0;


            for (int i = 0; i < input.Length; i++)
            {

                if (i % 2 == 0)
                {
                    evenDigit = Convert.ToInt32(input.Substring(i, 1));

                    doubled = evenDigit * 2;

                    if (doubled >= 10)
                    {
                        sumDoubledEvenDigits += 1 + (doubled % 10);
                    }
                    else
                    {
                        sumDoubledEvenDigits += doubled;
                    }
                }
                else
                {
                    oddDigit = Convert.ToInt32(input.Substring(i, 1));

                    sumOddDigits += oddDigit;
                }     
            }

            totalSum = sumDoubledEvenDigits + sumOddDigits;

            string result = totalSum % 10 == 0 ? "Number is correct." : "Number is not correct.";

            return result;
        }
    }
}
