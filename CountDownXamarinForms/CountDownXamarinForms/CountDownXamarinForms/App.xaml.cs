using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CountDownXamarinForms.Services;
using CountDownXamarinForms.Views;

namespace CountDownXamarinForms
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new CountDownPage();
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
