using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels
{
    public partial class ShopListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _nombreDElArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidad = 1;

        public ObservableCollection<ShopListItem> ShopList { get; }

        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
        }

        [RelayCommand]
        public void AddShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDElArticulo) || Cantidad <= 0)
            {
                return;
            }

            Random generador = new Random();
            var item = new ShopListItem()
            {
                Id = generador.Next(),
                Nombre = NombreDElArticulo,
                Cantidad = this.Cantidad,
                Comprado = false,
            };
            ShopList.Add(item);
            NombreDElArticulo = string.Empty;
            Cantidad = 1;
        }
        private void CargarDatos()
        {
            ShopList.Add(new ShopListItem()
            {
                Id = 1,
                Nombre = "Pan de caja",
                Cantidad = 1,
                Comprado = false,
            });
            ShopList.Add(new ShopListItem()
            {
                Id = 2,
                Nombre = "Queso",
                Cantidad = 3,
                Comprado = false,
            });
            ShopList.Add(new ShopListItem()
            {
                Id = 3,
                Nombre = "Leche",
                Cantidad = 5,
                Comprado = false,
            });
        }
    }
}