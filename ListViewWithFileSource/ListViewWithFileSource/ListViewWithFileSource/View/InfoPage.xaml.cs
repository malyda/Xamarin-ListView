using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            NameLabel.Text = person.Surname;
            SurnameLabel.Text = person.Lastname;
            AgeLabel.Text = person.Age.ToString();
        }
    }
}
