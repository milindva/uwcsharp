using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ZipCodeValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxZipCode.Focus();
            uxSubmit.IsEnabled = false;
        }

        public bool ZipCodeInValidFormat(string input)
        {
            // Regular expressions for US Zip codes format with and without additional numbers after "-"
            var usZipCodeFormat1 = new Regex(@"(\b\d{5})");
            var usZipCodeFormat2 = new Regex(@"(\b\d{5}-\d{4})");

            //Regular expression for Canada Zip codes with assumption for length of 6 characters and letter and number repeating after one another
            // with first character being a letter in upper case only

            var canadaZipCodeFormat = new Regex(@"(^[A-Z]\d[A-Z]\d[A-Z]\d)");

            bool isNumber = !String.IsNullOrEmpty(input) && Char.IsNumber(input[0]);

            if (isNumber && input.Length <= 10)

            {
                return ((usZipCodeFormat1.IsMatch(input) || usZipCodeFormat2.IsMatch(input)));

            }

            else if (!isNumber && input.Length <= 6)

            {
                return (canadaZipCodeFormat.IsMatch(input));

            }

            else
                return false;

        }



        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ZipCodeInValidFormat(uxZipCode.Text))
                uxSubmit.IsEnabled = true;
            else
                uxSubmit.IsEnabled = false;
        }
    }
}




