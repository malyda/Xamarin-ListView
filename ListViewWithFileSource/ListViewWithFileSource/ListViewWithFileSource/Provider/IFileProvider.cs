using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewWithFileSource.Provider
{
    interface IFileProvider
    {
        Task<string> ReadDataAsync();
        Task<bool> WriteDataAsync(string dataL);
    }
}
