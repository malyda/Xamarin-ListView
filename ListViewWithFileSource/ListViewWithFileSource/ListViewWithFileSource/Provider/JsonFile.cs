using System.Threading.Tasks;
using PCLStorage;

namespace ListViewWithFileSource.Provider
{
    class JsonFile : IFileProvider
    {
        private readonly string FolderName = "MySubFolder";
        private readonly string FileName = "jsonDB.json";
        private readonly IFolder _storagePath = FileSystem.Current.LocalStorage;
        public async Task<string> ReadDataAsync()
        {
            IFolder folder = await GetFolder();
            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);

            return await file.ReadAllTextAsync();  
        }
        public async Task<bool> WriteDataAsync(string dataL)
        {
            IFolder folder = await GetFolder();

            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(dataL);

            return true;
        }

        private async Task<IFolder> GetFolder()
        {
           return await _storagePath.CreateFolderAsync(FolderName, CreationCollisionOption.OpenIfExists);
        }
    }
}
