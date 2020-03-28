using Refit;

namespace HSESupporter.Services
{
    public class ApiService
    {
        public IHseSupporterApi hseSupporterApi;

        public ApiService()
        {
            hseSupporterApi = RestService.For<IHseSupporterApi>("https://hse-supporter.herokuapp.com");
        }
    }
}