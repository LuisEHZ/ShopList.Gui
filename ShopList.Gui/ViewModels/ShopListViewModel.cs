using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//using Java.Beans;
using ShopList.Gui.Models;

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModel:INotifyPropertyChanged
    {
        private string _nombreDelArticulo = "Mantequilla";
        private int _cantidadAComprar = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NombreDelArticulo
        {
            get =>_nombreDelArticulo;
            set
            {
                if(_nombreDelArticulo != value)
                {
                    _nombreDelArticulo = value;
                    OnPropertyChanged(nameof(NombreDelArticulo));
                }
            }
        }
        public int CantidadAComprar
        {
            get => _cantidadAComprar;
            set
            {
                if (_cantidadAComprar != value)
                {
                    _cantidadAComprar = value;
                    OnPropertyChanged(nameof(CantidadAComprar));
                }
            }
        }
        
        public ObservableCollection<Item> Items { get; }

        public ICommand AgregarShopListItemCommand { get; private set; }

        public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            AgregarShopListItemCommand =new Command(AgregarShopListItem);
        }
        public void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo)|| CantidadAComprar<=0)
            {
                return;
            }
            Random generador = new Random();
            var item = new Item { Id =generador.Next(), Nombre = NombreDelArticulo, Cantidad = CantidadAComprar, Comprado = false };
            Items.Add(item);
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
        }
        public void eliminarShopListItem()
        {


        }
       
        private void CargarDatos()
        {

            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado=false

            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Pan de caja",
                Cantidad = 1,
                 Comprado = true
            });

            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamón",
                Cantidad = 500,
                 Comprado = false
            });

        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

           
        }

    }
}

