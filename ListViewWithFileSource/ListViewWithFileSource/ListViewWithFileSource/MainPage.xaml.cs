using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using Xamarin.Forms;

namespace ListViewWithFileSource
{
    public partial class MainPage : ContentPage
    {
        private string data;
        ImageSource imageSource = ImageSource.FromFile("homer4.png");
        public MainPage()
        {
            InitializeComponent();

            /* string vale = task().Result + "sss";
             Debug.WriteLine(vale); */
           
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++) persons.Add(new Person() { Lastname = "Jméno" + i, Surname = "Přijmení" + i, Age = i+20});

            var dataToWrite = JsonConvert.SerializeObject(persons);
            ReadAndWriteData(dataToWrite);

        }

        private void SelectedItemMethod(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine(e.ToString());
            Navigation.PushAsync(new InfoPage( e.Item as Person));
        }
        //https://msdn.microsoft.com/en-us/magazine/jj991977.aspx

        private void ReadAndWriteData(string dataToWrite)
        {
            var result = Task(dataToWrite);
           
        }

        private async Task<bool> Task(string dataToWrite)
        {

            await WriteDataAsync(dataToWrite);
            List<Person> persons = await ReadDataAsync();

            PeopleListViewNotFormatted.ItemsSource = persons;

            foreach (Person person in persons)
            {
                person.ProfilePhoto = imageSource;
            }

            PeopleListViewFormatted.ItemsSource = persons;

            return true;
        }
        private async Task<List<Person>> ReadDataAsync()
        {

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);

            IFile file = await folder.CreateFileAsync("jsonDB.json", CreationCollisionOption.OpenIfExists);

            data = await file.ReadAllTextAsync();

            List<Person> p = await System.Threading.Tasks.Task.Run(() => JsonConvert.DeserializeObject<List<Person>>(data));
            /*
            foreach (Person person in p)
            {
                Debug.WriteLine(person.ToString());
            }*/


            return p;
        }
        public async Task<bool> WriteDataAsync(string dataL)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists);

            IFile file = await folder.CreateFileAsync("jsonDB.json", CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(dataL);

            return true;
        }
    }
}
