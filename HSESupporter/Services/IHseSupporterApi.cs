using System.Collections.Generic;
using System.Threading.Tasks;
using HSESupporter.Models;
using Refit;

namespace HSESupporter.Services
{
    public interface IHseSupporterApi
    {
        [Post("/api/auth/token/login")]
        Task<AuthResult> Login([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);
    }
}