using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TokoBuku.Model;
using TokoBuku.Service;
using Xamarin.Forms;

namespace TokoBuku.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        ILoginService loginService;
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            loginService = DependencyService.Get<ILoginService>();
            LoginCommand = new AsyncCommand(LoginMethod);
        }

        private async Task LoginMethod()
        {
            var data = new User { username = _username, password = _password };
            loginService.Login(data);
        }
    }
}
