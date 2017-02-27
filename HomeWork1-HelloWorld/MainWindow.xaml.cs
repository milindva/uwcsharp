using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool uxNameHasText = false;
        bool uxPasswordHasText = false;
        public MainWindow()
        {
            InitializeComponent();

            //Setting the cursor/focus on Name text box for user entry

            uxName.Focus();

        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);

            //Clear contents of both the text boxes after submit button is clicked
            // and set the focus back to Name text box
            //Disable Submit button after it has been clicked 


            uxName.Clear();
            uxPassword.Clear();
            uxSubmit.IsEnabled = false;

            uxName.Focus();


            
        }

        // method for validating and enabling Submit button 
        private void ValidateSubmitEnabled()
        {
            if (uxNameHasText == true && uxPasswordHasText == true)
                uxSubmit.IsEnabled = true;

        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {

            // check if there is at least one character entered in Name text box
            if (uxName.Text.Length > 0)
                uxNameHasText = true;

            ValidateSubmitEnabled();
        }


        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

            // check if there is at least one character entered in Password text box
            if (uxPassword.Text.Length > 0)
                uxPasswordHasText = true;

            ValidateSubmitEnabled();
        }



    }
}

