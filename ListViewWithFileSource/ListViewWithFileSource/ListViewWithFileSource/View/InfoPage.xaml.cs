using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewWithFileSource.Entity;
using Xamarin.Forms;

namespace ListViewWithFileSource
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        public InfoPage(Person person)
        {
            InitializeComponent();
            NameLabel.Text = person.GetName;
            AgeLabel.Text = person.Age.ToString();
            ProfilePicture.Source = person.ProfilePhoto;
        }
    }
}
