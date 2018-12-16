using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SWAPIHelpers
{
    public class ApiHandlerWrapper : IApiHandlerWrapper
    {
        public async Task<string> GetApiCallResultAsync(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = await request.GetResponseAsync();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream == null) return string.Empty;
                    var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    if (responseStream == null) throw;
                    var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    var errorText = await reader.ReadToEndAsync();
                }
                throw;
            }
        }
    }
}