using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModel : INotifyPropertyChanged
    {
        private string _nombreDElArticulo = string.Empty;
        private int _cantidad = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NombreDelArticulo
        {
            get => _nombreDElArticulo;
            set
            {
                if (_nombreDElArticulo != value)
                {
                    _nombreDElArticulo = value;
                    OnPropertyChanged(nameof(NombreDelArticulo));
                }
            }
        }
        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }
        public ObservableCollection<ShopListItem> ShopList {  get; }

        public ICommand AddShopListItemCommand { get; private set; }

        public ShopListViewModel()
        {
            ShopList = new ObservableCollection<ShopListItem>();
            CargarDatos();
            AddShopListItemCommand = new Command(AddShopListItem);

        }
        public void AddShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || Cantidad <= 0)
            {
                return;
            }
            Random generador = new Random();
            var item = new ShopListItem()
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = this.Cantidad,
                Comprado = false,
            };
            ShopList.Add(item);
            NombreDelArticulo = string.Empty;
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
        private OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}