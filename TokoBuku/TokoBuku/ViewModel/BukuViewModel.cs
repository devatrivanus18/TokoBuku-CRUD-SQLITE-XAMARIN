using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TokoBuku.Model;
using TokoBuku.Service;
using TokoBuku.View;
using Xamarin.Forms;

namespace TokoBuku.ViewModel
{
    public class BukuViewModel : BaseViewModel
    {
        private ObservableCollection<Buku> _listBuku = new ObservableCollection<Buku>();
        public ObservableCollection<Buku> ListBuku { get => _listBuku; set => SetProperty(ref _listBuku, value); }
        private Buku _buku = new Buku();
        public Buku buku { get => _buku; set => SetProperty(ref _buku, value); }
        IServiceBuku bukuService;
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand PindahHalamanTambahCommand { get; set; }

        public ICommand ItemSelectedCommand { get; set; }
        public BukuViewModel()
        {
            bukuService = DependencyService.Get<IServiceBuku>();
            var data = bukuService.GetAllBukuAsync();
            AddCommand = new Command<object>(AddMethod);
            ItemSelectedCommand = new Command<object>(BukuSelected);
            PindahHalamanTambahCommand = new Command<object>(PindahHalamanTambah);
            SaveCommand = new Command<object>(SaveBuku);
            DeleteCommand = new Command<object>(DeleteData);
            ListBuku = bukuService.ListBuku;
        }

        private void DeleteData(object obj)
        {
            var data = obj as Buku;
            bukuService.DeleteBukuAsync(data);
            bukuService.ListBuku.Remove(data);
        }

        private void SaveBuku(object obj)
        {
            var data = new Buku
            {
                Title=buku.Title,
                Author=buku.Author,
                Price=buku.Price,
                Publisher=buku.Publisher,
                ISBN=buku.ISBN,
                Date=buku.Date
            };
            bukuService.SaveBukuAsync(data);
            ListBuku.Add(data);
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private void PindahHalamanTambah(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddPage());
        }

        private void BukuSelected(object arg)
        {
            var data = arg as Buku;
            bukuService.BukuDipilih(data);
            Application.Current.MainPage.Navigation.PushAsync(new DetailBukuPage());
        }

      
        private async void AddMethod(object arg)
        {
            var data = new Buku{Title=buku.Title,Date=buku.Date };
            await bukuService.SaveBukuAsync(data);
            ListBuku.Add(data);
        }
    }
}
