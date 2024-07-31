using System;
using System.Windows.Forms;

namespace SimpleCalculatorGUI
{
    public partial class Form1 : Form
    {
        private TextBox display;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            // Initialize display
            display = new TextBox();
            display.Location = new System.Drawing.Point(10, 10);
            display.Width = 260;
            display.ReadOnly = true;
            display.TextAlign = HorizontalAlignment.Right;
            Controls.Add(display);

            // Initialize buttons
            string[] buttons = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };
            int xPos = 10, yPos = 50;

            foreach (string btnText in buttons)
            {
                Button btn = new Button();
                btn.Text = btnText;
                btn.Width = 60;
                btn.Height = 40;
                btn.Left = xPos;
                btn.Top = yPos;
                btn.Click += Button_Click;
                Controls.Add(btn);

                xPos += 65;
                if (xPos > 250)
                {
                    xPos = 10;
                    yPos += 45;
                }
            }
        }

        private string input = "";
        private string operation = "";
        private double result = 0;

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Text == "C")
            {
                display.Text = "";
                input = "";
                operation = "";
                result = 0;
                return;
            }

            if (btn.Text == "=")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    Calculate();
                    display.Text = result.ToString();
                    input = result.ToString();
                    operation = "";
                }
                return;
            }

            if ("+-*/".Contains(btn.Text))
            {
                if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(input))
                {
                    Calculate();
                    display.Text = result.ToString();
                }
                operation = btn.Text;
                result = double.Parse(input);
                input = "";
                return;
            }

            input += btn.Text;
            display.Text = input;
        }

        private void Calculate()
        {
            if (!string.IsNullOrEmpty(input))
            {
                double secondOperand = double.Parse(input);

                switch (operation)
                {
                    case "+":
                        result += secondOperand;
                        break;
                    case "-":
                        result -= secondOperand;
                        break;
                    case "*":
                        result *= secondOperand;
                        break;
                    case "/":
                        result /= secondOperand;
                        break;
                }
            }
        }
    }
}
