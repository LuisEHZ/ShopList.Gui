using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using ShopList.Gui.Persistence;


namespace ShopList.Gui.ViewModels
{
    public partial class ShopListViewModel:ObservableObject
    {
        


        [ObservableProperty]
        private Item? itemSeleccionado = null;

        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;




        [ObservableProperty]
        private ObservableCollection<Item>? items = null;
        private ShopListDatabase? _database =null ;
       
       

        public ShopListViewModel()
        {
           _database = new ShopListDatabase();
            Items = new ObservableCollection<Item>();
          GetItems();
            //CargarDatos();
           
        }

        [RelayCommand]

        public async void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar<=0)
            {
                return;
            }
            //    Random generador = new Random();

                 var item = new Item {// Id =generador.Next(), 
                     Nombre = NombreDelArticulo, Cantidad = CantidadAComprar, Comprado = false };

            // Items.Add(item);
           
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
        }


        [RelayCommand]
        public void EliminarShopListItem()
        {
            if (ItemSeleccionado == null)
            {
                return;
            }

            var index = Items.IndexOf(ItemSeleccionado);

            Item? nuevoSeleccionado = null;

            if (Items.Count > 1)
            {
                // Si NO es el último elemento
                if (index < Items.Count - 1)
                {
                    nuevoSeleccionado = Items[index + 1];   // Selecciona el siguiente
                }
                else
                {
                    nuevoSeleccionado = Items[index - 1];   // Selecciona el anterior
                }
            }

            Items.Remove(ItemSeleccionado);

          //Si no hay nada q seleccionar
            ItemSeleccionado = nuevoSeleccionado;
        }

        private async void GetItems()
        {
            IEnumerable<Item> ItemFromDB = await _database.GetAllItemAsync();
            Items = new ObservableCollection<Item>(ItemFromDB);

            
            //foreach (var item in items)
            //    Items.Add(item);
        }



        //private void CargarDatos()
        //{

        //    Items.Add(new Item()
        //    {
        //        Id = 1,
        //        Nombre = "Leche",
        //        Cantidad = 2,
        //        Comprado=false

        //    });

        //    Items.Add(new Item()
        //    {
        //        Id = 2,
        //        Nombre = "Pan de caja",
        //        Cantidad = 1,
        //         Comprado = true
        //    });

        //    Items.Add(new Item()
        //    {
        //        Id = 3,
        //        Nombre = "Jamón",
        //        Cantidad = 500,
        //         Comprado = false
        //    });

        //}
        

    }
}

