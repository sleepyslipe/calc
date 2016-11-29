using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class Calculator_form : Form
    {
        double value1; // первое значение
        double value2; // второе значение
        double result; // результат
        String label = null; // последнее значение
        String last_symbol = null;
        Regex reg1 = new Regex("[a-z]"); // регулярное выражение
        int count; // 1+ 2- 3* 4/

        public Calculator_form()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text.Replace(".", ",");
            if (reg1.IsMatch(textBox.Text) == true) // если поле ввода содержит буквы
            {
                textBox.Text = reg1.Replace(textBox.Text, String.Empty); // удалить буквы
            }
            last_symbol = Convert.ToString(textBox.Text.Last());
            label += last_symbol;
            textBox.SelectionStart = textBox.Text.Length; // переместить каретку в конец строки

            switch (last_symbol)
            {
                case "1":
                    button_plus.PerformClick();
                    break;
                case "2":
                    button_minus.PerformClick();
                    break;
                case "3":
                    button_multiply.PerformClick();
                    break;
                case "4":
                    button_divide.PerformClick();
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox.Text += 1;
            //label += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox.Text += 2;
            //label += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox.Text += 3;
            //label += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox.Text += 4;
            //label += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox.Text += 5;
            //label += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox.Text += 6;
            //label += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox.Text += 7;
            //label += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox.Text += 8;
            //label += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox.Text += 9;
           // label += 9;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox.Text += 0;
           // label += 0;
        }

        private void button_coma_Click(object sender, EventArgs e)
        {
            textBox.Text += ",";
            //label += ",";
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            textBox.Text += "+";
            value1 = Convert.ToDouble(label);
            label = label.Remove(0);
            count = 1;
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            textBox.Text += "-";
            if (label.Length > 0)
            {
                value1 = Convert.ToDouble(label);
                label = label.Remove(0);
                count = 2;
            }
            else
            {
                label += "-";
            }
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            textBox.Text += "*";
            value1 = Convert.ToDouble(label);
            label = label.Remove(0);
            count = 3;
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            textBox.Text += "/";
            value1 = Convert.ToDouble(label);
            label = label.Remove(0);
            count = 4;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1); // удалить последний элемент строки
            }
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            if (label.Length != 0)
            {
                label = label.Remove(0);
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            value2 = Convert.ToDouble(label);
            label = label.Remove(0);

            switch (count)
            {
                case 1:
                    result = value1 + value2;
                    break;
                case 2:
                    result = value1 - value2;
                    break;
                case 3:
                    result = value1 * value2;
                    break;
                case 4:
                    result = value1 / value2;
                    break;
            }
            textBox.Text += "=";
            textBox.Text += result.ToString();
        }
    }
}
