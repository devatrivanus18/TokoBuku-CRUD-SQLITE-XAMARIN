using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TokoBuku.Model;
using TokoBuku.Service;
using TokoBuku.View;
using Xamarin.Forms;

namespace TokoBuku.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        IServiceBuku bukuService;
        private Buku _BukuTerpilih = new Buku();

        public Buku BukuTerpilih { get => _BukuTerpilih; set => SetProperty(ref _BukuTerpilih, value); }
        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }
        public DetailViewModel()
        {
            bukuService = DependencyService.Get<IServiceBuku>();
            BukuTerpilih = bukuService.BukuTerpilih;
            UpdateCommand = new Command<object>(UpdateData);
            DeleteCommand = new Command<object>(DeleteData);
        }

        private void DeleteData(object obj)
        {
            bukuService.DeleteBukuAsync(BukuTerpilih);
            bukuService.ListBuku.Remove(BukuTerpilih);
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private void UpdateData(object obj)
        {
            bukuService.SaveBukuAsync(BukuTerpilih);
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}
