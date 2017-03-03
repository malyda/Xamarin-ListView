using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListViewWithFileSource.Entity
{
   public class Person
    {

        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public ImageSource ProfilePhoto { get; set; }

        public string GetName => Lastname + " " + Firstname;

        
        public override string ToString()
        {
            return Firstname + " " + Lastname + " " + Age;
            // return "Firstname: " + Firstname + " Lastname " + Lastname + " Age: "+ Age;
        }
    }
}
