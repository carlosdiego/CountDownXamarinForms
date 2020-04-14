using CountDownXamarinForms.Services;
using CountDownXamarinForms.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CountDownXamarinForms.ViewModels
{
    public class CountDownViewModel : BaseViewModel
    {
        private CountDown countDown;
        private double seconds = 10;

        private double _countProgress;
        public double CountProgress
        {
            get { return _countProgress; }
            set
            {
                _countProgress = value;
                OnPropertyChanged();
            }
        }

        public ICommand MoreTimeCommand => new Command(AddTime);
        public CountDownViewModel()
        {
            Title = "About";

            countDown = new CountDown(TimeSpan.FromSeconds(seconds), TimeSpan.FromMilliseconds(100), UpdateCount, GoNewPageAfterTime);
        }
                
        private void GoNewPageAfterTime()
        {
            Application.Current.MainPage = new NavigationPage(new NewPage());
        }

        private void AddTime()
        {
            countDown?.AddCountProgress(0.50);
        }

        private void UpdateCount(double update)
        {
            CountProgress = update;
        }
    }
}