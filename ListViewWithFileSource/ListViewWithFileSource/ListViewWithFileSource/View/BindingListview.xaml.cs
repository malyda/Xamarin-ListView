using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ListViewWithFileSource.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewWithFileSource.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingListview : ContentPage
    {
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        public ICommand SelectedItemCommand { get; set; }
        public BindingListview()
        {
            InitializeComponent();
            
            SelectedItemCommand = new Command<Person>(SelectedItemCommandImplementation);
            
            CreateSampleData();
            this.BindingContext = this;

        }

        private void SelectedItemCommandImplementation(Person person)
        {

        }
        private void CreateSampleData()
        {
           
            Persons.Add(new Person() { Lastname = "Jan", Firstname = "Valentýn", DateOfBirth = new DateTime(1980 + 20, 1, 1) });
            Persons.Add(new Person() { Lastname = "Benedikt", Firstname = "Vojtěch", DateOfBirth = new DateTime(1980 + 11, 1, 1) });
            Persons.Add(new Person() { Lastname = "Vern", Firstname = "Argento", DateOfBirth = new DateTime(1980 + 13, 1, 1) });
            Persons.Add(new Person() { Lastname = "Caroline", Firstname = "Erben", DateOfBirth = new DateTime(1980 + 5, 1, 1) });
            Persons.Add(new Person() { Lastname = "Elton", Firstname = "Saas", DateOfBirth = new DateTime(1980 + 20, 1, 1) });
            // for (int i = 0; i < 10; i++) persons.Add(new Person() { Lastname = "Jméno" + i, Firstname = "Přijmení" + i, DateOfBirth = new DateTime(1980+i,1,1) });
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            var switchItem = (Switch)sender;
            Person SelectedParent = (Person) switchItem.BindingContext;
        }
    }
}