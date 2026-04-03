using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zakonWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>Проверка, что поле не пустое</summary>
        public static bool IsFieldFilled(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
        /// <summary>Проверка, что введено число</summary>
        public static bool IsNumber(string text)
        {
            return double.TryParse(text, out _);
        }

        /// <summary>
        /// сила тока: I = U/R
        /// </summary>
        public static double CalculateCurrent(double voltage, double resistance)
        {
            if (resistance == 0)
                throw new DivideByZeroException("Cопротивление не может быть нулевым");
            return voltage / resistance;
        }
        /// <summary>
        /// напряжение:U = I*R
        /// </summary>
        public static double CalculateVoltage(double current, double resistance)
        {
            return current * resistance;
        }
        /// <summary>
        /// сопротивление: R = U/I
        /// </summary>
        public static double CalculateResistance(double voltage, double current)
        {
            if (current == 0)
                throw new DivideByZeroException("Сила тока не может быть нулевой");
            return voltage / current;
        }
        /// <summary>
        /// смена названия полей
        /// </summary>
        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            if (RbCurrent.IsChecked == true)
            {
                Label1.Text = "Напряжение (Вольт):";
                Label2.Text = "Сопротивление (Ом):";
                ResultLabel.Text = "Сила тока =";
            }
            else if (RbVoltage.IsChecked == true)
            {
                Label1.Text = "Сила тока (Ампер):";
                Label2.Text = "Сопротивление (Ом):";
                ResultLabel.Text = "Напряжение =";
            }
            else if (RbResistance.IsChecked == true)
            {
                Label1.Text = "Напряжение (Вольт):";
                Label2.Text = "Сила тока (Ампер):";
                ResultLabel.Text = "Сопротивление =";
            }
        }
        /// <summary>
        /// кнопочка вычислить
        /// </summary>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Input1.Text) || string.IsNullOrWhiteSpace(Input2.Text))
                {
                    MessageBox.Show("Заполните оба поля!", "Ошибка");
                    return;
                }

                if (!double.TryParse(Input1.Text, out double val1) || !double.TryParse(Input2.Text, out double val2))
                {
                    MessageBox.Show("Введите числа!", "Ошибка");
                    return;
                }

                double result = 0;

                if (RbCurrent.IsChecked == true)
                {
                    result = CalculateCurrent(val1, val2);
                }
                else if (RbVoltage.IsChecked == true)
                {
                    result = CalculateVoltage(val1, val2);
                }
                else
                {
                    result = CalculateResistance(val1, val2);
                }

                ResultBox.Text = $"{result:F3}";
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
