using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E621ImageDownloader.Helpers
{
    public static class Helper
    {

        public static async Task<byte[]> Downloader(this Uri post)
        {
            HttpClient client = new HttpClient();

            byte[] x = await client.GetByteArrayAsync(post);

            return x;
            

        }

    }
}
