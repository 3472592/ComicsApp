using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace Comics_App_For_Jimmy
{
    public class SuspensionManager
    {
        public static string CurrentQuery { get; set; }

        private const string filename = "_SessionState.txt";

        static async public Task SaveAsync()
        {
            if(String.IsNullOrEmpty(CurrentQuery))
                CurrentQuery = String.Empty;

            IStorageFile storageFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(
                        filename, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(storageFile, CurrentQuery);
        }

        static async public Task RestoreAsync()
        {
            IStorageFile storageFile =
                await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            CurrentQuery = await FileIO.ReadTextAsync(storageFile);
        }
    }
}
