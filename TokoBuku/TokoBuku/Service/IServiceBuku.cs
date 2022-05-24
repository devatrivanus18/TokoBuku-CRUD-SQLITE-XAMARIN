using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TokoBuku.Model;

namespace TokoBuku.Service
{
    public interface IServiceBuku
    {
        Buku BukuTerpilih { get; set; }
        Task<List<Buku>> GetAllBukuAsync();
        Task<int> SaveBukuAsync(Buku buku);
        Task<Buku> GetBukuAsync(int id);
        Task<int> DeleteBukuAsync(Buku buku);
        void BukuDipilih(Buku buku);
        ObservableCollection<Buku> ListBuku { get; set; }


    }
}
