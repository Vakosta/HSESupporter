using System.Threading.Tasks;
using Refit;
using Xamarin.Essentials;

namespace HSESupporter.Services
{
    public class ApiService
    {
        public readonly IHseSupporterApi HseSupporterApi;

        public ApiService()
        {
            var refitSettings = new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(TokenHeader)
            };
            HseSupporterApi = RestService.For<IHseSupporterApi>("https://hse-supporter.herokuapp.com", refitSettings);
        }

        public static string TokenHeader => $"{Preferences.Get("token", "")}";
    }
}