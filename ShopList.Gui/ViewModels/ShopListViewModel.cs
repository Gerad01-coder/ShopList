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
        [ObservableProperty]
        private ShopListItem _elementoSeleccionado = null;

        public ObservableCollection<ShopListItem> ShopList { get; }

        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
            if (ShopList.Count > 0)
            {
                ElementoSeleccionado = ShopList[0];
            } 
            else
            {
                ElementoSeleccionado = null;
            }
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
            ElementoSeleccionado = item;
            NombreDElArticulo = string.Empty;
            Cantidad = 1;
        }

        [RelayCommand]
        public void RemoveShoplistItem()
        {
            if (ElementoSeleccionado == null)
            {
                return;
            }
            ShopListItem? nuevoElementoSeleccionado;
            int indice = ShopList.IndexOf(ElementoSeleccionado);
            if (ShopList.Count > 1)
            {
                if(indice == ShopList.Count - 1)
                {
                    //Es el ultimo elemento
                    nuevoElementoSeleccionado = ShopList[indice - 1];
                }
                else
                {
                    //No es el ultimo elemento
                    nuevoElementoSeleccionado = ShopList[indice + 1];
                }
            }
            else
            {
                 //Es el unico elemento
                 nuevoElementoSeleccionado = null;
            }
            ShopList.Remove(ElementoSeleccionado);
            ElementoSeleccionado = nuevoElementoSeleccionado;
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