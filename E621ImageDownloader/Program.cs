using E621_Wrapper;
using E621ImageDownloader.Database;

namespace E621ImageDownloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Api x = new Api("", "", "Image Downloader v22.1");

            string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            SqlFunctions sqlFunctions = new SqlFunctions();

            sqlFunctions.CreateDatabase();

            List<string> tags = await sqlFunctions.Read();
            
                         
            

                
            
            
        }
    }
}
