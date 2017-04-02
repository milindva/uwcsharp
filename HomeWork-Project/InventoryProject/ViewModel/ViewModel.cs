using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity.Infrastructure;
using InventoryDataModel;
using System.Data.Entity;

namespace InventoryProject.ViewModel
{
    public class ProductViewModel : ViewModelBaseClass
    {
        public Window CallingForm; // Used to close the form. Not a property, just a field.

        private int recordcount;
        public int RecordCount
        {
            get { return recordcount; }
            set
            {
                recordcount = value;
                RaisePropertyChanged("RecordCount");
            }
        }

        public CommandMap _commands;
        public CommandMap Commands { get { return _commands; } }

        InventoryEntities mgr;

        public ObservableCollection<Product> product { get; set; }

        private Product selectedproduct;
        public Product SelectedProduct
        {
            get {return selectedproduct; }

            set
            {
                selectedproduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        public ProductViewModel()
        {
            mgr = new InventoryEntities();
            product = new ObservableCollection<Product>();
            _commands = new CommandMap();

            _commands.AddCommand("Add", x => Add(), x => !CanSave());
            _commands.AddCommand("Save", x => Save(), x => CanSave());
            _commands.AddCommand("Cancel", x => Cancel(), x => CanSave());
            _commands.AddCommand("Delete", x => Delete(), x => !CanSave());
            _commands.AddCommand("Close", x => Close(), x => !CanSave());

            LoadData();
        }

        private void LoadData()
        {
            product.Clear();
            var query = mgr.Products;
            foreach (Product P in query) { product.Add(P); }
            RecordCount = product.Count;
            SelectedProduct = product[0];
        }

        void Add()
        {
            
            Product NewProduct = new Product();
            NewProduct.CreatedDate = System.DateTime.Now;
           

            mgr.Products.Add(NewProduct);
            product.Add(NewProduct);
            SelectedProduct = NewProduct;

  
        }

        void Delete()
        {
            if (MessageBox.Show
              ("Delete selected row?",
              "Not undoable", MessageBoxButton.YesNo,
              MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                mgr.Products.Remove(SelectedProduct);
                mgr.SaveChanges();
                product.Remove(SelectedProduct);
                SelectedProduct = product[0];
                RecordCount = product.Count;
                             
            }
        }

        void Save()
        {
            mgr.SaveChanges();
            RecordCount = product.Count;
        }

        bool CanSave()
        { return mgr.ChangeTracker.HasChanges(); }

        void Cancel()
        {
            foreach (DbEntityEntry entry in mgr.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged; break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached; break;
                    case EntityState.Deleted:
                        entry.Reload(); break;
                    default: break;
                }
            }
            LoadData();
        }

        void Close()
        {
            if (CallingForm == null)
            { MessageBox.Show("Callingform wasn't assigned in codebehind"); }
            else { CallingForm.Close(); }
        }
    }
}
