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
using InventoryProject.ViewModel;

namespace InventoryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

  public partial class MainWindow : Window
    {

        public ProductViewModel vm;
        public MainWindow()
        {
            InitializeComponent();

            vm = new ProductViewModel();
            vm.CallingForm = this; //so that the ViewModel can close the form
            DataContext = vm;

            
        }

        private void DataGrid_AutoGeneratingColumn(object sender,  System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ItemID")
                e.Column.Visibility = Visibility.Collapsed;

            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] headings = { "Hidden", "Description", "PricePerItem", "Qty On hand", "Our Cost per Item", "Created Date" };
            for (int I = 0; I < headings.Length; I++) { grid.Columns[I].Header = headings[I]; }
        }

     
    }
}
