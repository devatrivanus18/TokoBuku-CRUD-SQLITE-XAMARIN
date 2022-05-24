using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TokoBuku.Model;
using TokoBuku.Service;
using Xamarin.Forms;

[assembly: Dependency(typeof(ServiceBuku))]
namespace TokoBuku.Service
{
    public class ServiceBuku : BaseViewModel,IServiceBuku
    {

        readonly SQLiteAsyncConnection database;
        private Buku _BukuTerpilih = new Buku();

        public Buku BukuTerpilih { get => _BukuTerpilih; set => SetProperty(ref _BukuTerpilih,value); }

        private ObservableCollection<Buku> _listBuku = new ObservableCollection<Buku>();
        public ObservableCollection<Buku> ListBuku { get => _listBuku; set => SetProperty(ref _listBuku, value); }

        public ServiceBuku()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Note.db3");
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Buku>().Wait();
            getdata();
        }

        public void getdata()
        {
            var data = GetAllBukuAsync().Result;
            foreach (var item in data)
            {
                ListBuku.Add(item);
            }
        }

        public void BukuDipilih(Buku buku)
        {
            BukuTerpilih = buku;
        }

        public Task<int> DeleteBukuAsync(Buku buku)
        {
            return database.DeleteAsync(buku);
        }

        public Task<List<Buku>> GetAllBukuAsync()
        {
            return database.Table<Buku>().ToListAsync();
        }

        public Task<Buku> GetBukuAsync(int id)
        {
            return database.Table<Buku>()
                           .Where(i => i.ID == id)
                           .FirstOrDefaultAsync();
        }

        public Task<int> SaveBukuAsync(Buku buku)
        {
            if (buku.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(buku);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(buku);
            }
        }
    }
}
