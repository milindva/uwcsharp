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
using System.Windows.Shapes;
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        private ListSortDirection dirToSort = ListSortDirection.Ascending;

        public SecondWindow()
        {


            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });
            // users.Add(new Models.User { Name = "Test", Password = "3TestPwd" });

            uxList.ItemsSource = users;



        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {


            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            string sortBy = column.Tag.ToString();

            // if the  column is clicked for the first time , sort in ascending direction
            if (listViewSortCol != null) 
                uxList.Items.SortDescriptions.Clear();

            ListSortDirection newDir = ListSortDirection.Ascending;

            if (listViewSortCol == column) //if the same column is clicked again, change sort direction
                newDir = ListSortDirection.Descending;

            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

            listViewSortCol = column;


        }


    }


}

