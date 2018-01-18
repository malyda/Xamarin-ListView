using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ListViewWithFileSource
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            // OR Listview Binding
            MainPage = new NavigationPage(new View.MainPage());
            // OR Listview Binding
            MainPage = new NavigationPage(new View.BindingListview());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
