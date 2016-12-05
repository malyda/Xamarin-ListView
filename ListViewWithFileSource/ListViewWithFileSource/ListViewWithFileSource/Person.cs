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
        public string Surname { get; set; }
        public int Age { get; set; }

        public ImageSource ProfilePhoto { get; set; }

        public string GetName => Lastname + " " + Surname;

        public override string ToString()
        {
            return "Surname: " + Surname + " Lastname " + Lastname + " Age: "+ Age;
        }
    }
}
