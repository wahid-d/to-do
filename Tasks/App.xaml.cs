using System;
using Tasks.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "Expander_Experimental" });

            MainPage = new MainShell();
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
