using System;
using System.IO;
using TokoBuku.Service;
using TokoBuku.View;
using Xamarin.Forms;

namespace TokoBuku
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
