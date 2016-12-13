using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewWithFileSource
{
   public class Person
    {

        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public int Age
        {
            get { return DateTime.Now.Year - DateOfBirth.Year; }
        }

        public DateTime DateOfBirth { get; set; }

        public ImageSource ProfilePhoto { get; set; }

        public string GetName => Lastname + " " + Firstname;

        
        public override string ToString()
        {
            return Firstname + " " + Lastname + " " + Age;
            // return "Firstname: " + Firstname + " Lastname " + Lastname + " Age: "+ Age;
        }
    }
}
