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
            display.Font = new System.Drawing.Font("Arial", 18);
            display.Height = 40;
            Controls.Add(display);

            // Initialize TableLayoutPanel for buttons
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.RowCount = 5;
            tableLayout.ColumnCount = 4;
            tableLayout.Location = new System.Drawing.Point(10, 60);
            tableLayout.Width = 260;
            tableLayout.Height = 300;
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayout.AutoSize = true;
            tableLayout.ColumnStyles.Clear();
            tableLayout.RowStyles.Clear();
            for (int i = 0; i < 4; i++)
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++)
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            
            string[] buttons = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };

            foreach (string btnText in buttons)
            {
                Button btn = new Button();
                btn.Text = btnText;
                btn.Font = new System.Drawing.Font("Arial", 16);
                btn.Dock = DockStyle.Fill;
                btn.Click += Button_Click;
                tableLayout.Controls.Add(btn);
            }

            Controls.Add(tableLayout);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string buttonText = btn.Text;

            if (buttonText == "C")
            {
                display.Clear();
            }
            else if (buttonText == "=")
            {
                try
                {
                    var result = new System.Data.DataTable().Compute(display.Text, null);
                    display.Text = result.ToString();
                }
                catch
                {
                    display.Text = "Error";
                }
            }
            else
            {
                display.Text += buttonText;
            }
        }
    }
}
