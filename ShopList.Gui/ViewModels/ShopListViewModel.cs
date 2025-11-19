using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopList.Gui.Models;

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public ShopListViewModel() 
        {
        Items = new ObservableCollection<Item> { new Item() };
        
        }
        private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,Nombre="Leche",Cantidad=100
            }); Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Pan",
                Cantidad = 100
            }); Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Jamón",
                Cantidad = 100
            }); Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Miel",
                Cantidad = 100
            });
        }
    }
}
