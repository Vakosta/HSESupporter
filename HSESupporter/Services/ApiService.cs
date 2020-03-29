using Refit;
using Xamarin.Essentials;

namespace HSESupporter.Services
{
    public class ApiService
    {
        public readonly IHseSupporterApi HseSupporterApi;

        public ApiService()
        {
            HseSupporterApi = RestService.For<IHseSupporterApi>("https://hse-supporter.herokuapp.com");
        }

        public static string TokenHeader => $"Token {Preferences.Get("token", "")}";
    }
}