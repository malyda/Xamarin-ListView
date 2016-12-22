using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewWithFileSource.Entity;

namespace ListViewWithFileSource.Helper
{
    class JsonHelper
    {
        public string SerializeObject(List<Person> p)
        {
            return Task.Run(() => JsonConvert.SerializeObject(p)).Result;
        }

        public List<Person> DeserializeObject(string jsonData)
        {
            return Task.Run(() => JsonConvert.DeserializeObject<List<Person>>(jsonData)).Result;
        }
    }
}
