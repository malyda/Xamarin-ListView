using ListViewWithFileSource.Provider;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewWithFileSource.Privider
{
    class JsonFile : IFileProvider
    {
        private readonly string FolderName = "MySubFolder";
        private readonly string FileName = "jsonDB.json";
        private readonly IFolder StoragePath = FileSystem.Current.LocalStorage;
        public async Task<string> ReadDataAsync()
        {
            IFolder folder = await getFolder();

            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);

         return await file.ReadAllTextAsync();

          
        }
        public async Task<bool> WriteDataAsync(string dataL)
        {
            IFolder folder = await getFolder();

            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(dataL);

            return true;
        }

        private async Task<IFolder> getFolder()
        {
           return await StoragePath.CreateFolderAsync(FolderName, CreationCollisionOption.OpenIfExists);
        }
    }
}
