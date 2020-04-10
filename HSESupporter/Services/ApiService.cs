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
            HseSupporterApi = RestService.For<IHseSupporterApi>("http://127.0.0.1:8000", refitSettings);
        }

        public static string TokenHeader => $"{Preferences.Get("token", "")}";
    }
}