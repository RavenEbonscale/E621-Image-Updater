using E621_Wrapper;
using E621ImageDownloader.Database;
using E621ImageDownloader.Helpers;

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

            List<int> ids = await sqlFunctions.Readids();

            foreach (string tag in tags)
            {
                if (!Directory.Exists(PictureFolder + @$"\{tag.Replace(":", "").Replace(">", "")}"))
                {
                    Directory.CreateDirectory(PictureFolder + @$"\{tag.Replace(":","").Replace(">","")}");
                }
            }

            foreach (string tag in tags)
            {
                List<E621json> jsons = x.Get_Posts(tag.Split(",").ToList(),5);

              
                foreach (E621json j in jsons)
                {
                    foreach (E621json.Post post in j.posts)
                    {
                        if (ids.Contains(post.id)) { 
                        continue;
                        }

                        try
                        {
                            byte[] imagearray = await new Uri(post.file.url).Downloader();


                            await File.WriteAllBytesAsync(PictureFolder + @$"\{tag.Replace(":", "").Replace(">", "")}\{post.file.md5}.{post.file.ext}", imagearray);

                            await sqlFunctions.Update(tag, post.id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());   

                        }


                    }




                }





            }
        }
    }
}
