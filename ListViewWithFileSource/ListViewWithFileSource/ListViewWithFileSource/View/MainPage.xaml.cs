using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListViewWithFileSource.Entity;
using ListViewWithFileSource.Helper;
using ListViewWithFileSource.Provider;
using Xamarin.Forms;

namespace ListViewWithFileSource.View
{
    public partial class MainPage : ContentPage
    {
        readonly ImageSource _imageSource = ImageSource.FromFile("homer4.png");

        readonly JsonFile _jsonFileProvider = new JsonFile();
        readonly JsonHelper _jsonHelper = new JsonHelper();
        public MainPage()
        {
            InitializeComponent();

            List<Person> persons = CreateSampleData();
            SetListViewItems(persons);

            string dataToWrite =  _jsonHelper.SerializeObject(persons);
            ReadAndWriteData(dataToWrite);
        }

        private List<Person> CreateSampleData()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Lastname = "Jan", Firstname = "Valentýn", DateOfBirth = new DateTime(1980 + 20, 1, 1) });
            persons.Add(new Person() { Lastname = "Benedikt", Firstname = "Vojtěch", DateOfBirth = new DateTime(1980 + 11, 1, 1) });
            persons.Add(new Person() { Lastname = "Vern", Firstname = "Argento", DateOfBirth = new DateTime(1980 + 13, 1, 1) });
            persons.Add(new Person() { Lastname = "Caroline", Firstname = "Erben", DateOfBirth = new DateTime(1980 + 5, 1, 1) });
            persons.Add(new Person() { Lastname = "Elton", Firstname = "Saas", DateOfBirth = new DateTime(1980 + 20, 1, 1) });
            // for (int i = 0; i < 10; i++) persons.Add(new Person() { Lastname = "Jméno" + i, Firstname = "Přijmení" + i, DateOfBirth = new DateTime(1980+i,1,1) });
            return persons;
        }

        private void SelectedItemMethod(object sender, ItemTappedEventArgs e)
        {
            // Grab ListView Item as Person object and send it as parameter to constructor of InfoPage
            Navigation.PushAsync(new InfoPage( e.Item as Person));
        }
        //https://msdn.microsoft.com/en-us/magazine/jj991977.aspx

        private void ReadAndWriteData(string dataToWrite)
        {
            List<Person> persons = Task.Run( () => ReadAndWriteAsync(dataToWrite)).Result;
            SetListViewItems(persons);
        }

        private void SetListViewItems(List<Person> persons)
        {
            PeopleListViewNotFormatted.ItemsSource = persons;

            foreach (Person person in persons)
            {
                person.ProfilePhoto = _imageSource;
            }

            PeopleListViewFormatted.ItemsSource = persons;
        }


        private async Task<List<Person>> ReadAndWriteAsync(string dataToWrite)
        {
            await _jsonFileProvider.WriteDataAsync(dataToWrite);
            string dataFromFile = await _jsonFileProvider.ReadDataAsync();

            return _jsonHelper.DeserializeObject(dataFromFile);
       }   
    }
}
