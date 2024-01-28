using BlazorWebClient.Interfaces;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;
using System.Net;

namespace BlazorWebClient.Services
{
    public class TranslateService : ITranslateService
    {
        public async Task<string> TranslateTextAsync(string text)
        {
            var toLanguage = "en";
            var fromLanguage = "uk";
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(text)}";
            var httpClient = new HttpClient();
            
            var result = await httpClient.GetAsync(url);
            try
            {
                string resultStr = await result.Content.ReadAsStringAsync();
                resultStr = resultStr.Substring(4, resultStr.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return resultStr;
            }
            catch
            {
                return "Error";
            }
        }
    }
}
