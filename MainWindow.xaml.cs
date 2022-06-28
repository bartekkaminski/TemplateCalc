using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace TemplateCalc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Message when something wrong
        private string invalidFormat = "Wrong data format";

        // Calc function
        private void Calc(object sender, RoutedEventArgs e)
        {
            AreaResult.Text = GetArea().ToString();
            CircuitResult.Text = GetCircuit().ToString();
        }

        // Calculate Area
        private double GetArea()
        {
            try
            {
                ShowMessage("");
                return double.Parse(Field1.Text) * double.Parse(Field2.Text); // Main logic function
            }
            catch
            {
                ShowMessage(invalidFormat);
                return 0;
            }
        }

        // Calculate Circuit
        private double GetCircuit()
        {
            try
            {
                ShowMessage("");
                return (2 * double.Parse(Field1.Text)) + (2 * double.Parse(Field2.Text)); // Main logic function
            }
            catch
            {
                ShowMessage(invalidFormat);
                return 0;
            }
        }

        // Validation numbers in inputs
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Function to show message when something wrong
        private void ShowMessage(string text)
        {
            MessageBox.Text = text;
        }
    }
}
