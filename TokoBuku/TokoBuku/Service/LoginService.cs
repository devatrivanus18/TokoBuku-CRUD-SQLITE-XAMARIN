using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoBuku.Model;
using TokoBuku.Service;
using TokoBuku.View;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginService))]
namespace TokoBuku.Service
{
    public class LoginService : BaseViewModel, ILoginService
    {
        ObservableCollection<User> _users = new ObservableCollection<User>();
        ObservableCollection<User> users { get => _users; set => SetProperty(ref _users, value); }
        public LoginService()
        {
            ListUser();
        }
        public void ListUser()
        {
            users.Add(new User { username="deva",password="deva"});
            users.Add(new User { username = "admin", password = "admin" });
        }

        public async void Login(User user)
        {
            var data = users.Where(x => x.username == user.username).FirstOrDefault();
            if (data !=null)
            {
                if (user.username==data.username && user.password==data.password)
                {
                    await Application.Current.MainPage.DisplayAlert("Sukses", "berhasil login", "OK");
                    Preferences.Set("Username", user.username);
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Gagal", "Username atau Password salah", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Gagal", "User tidak ada", "OK");
            }

        }
    }
}
