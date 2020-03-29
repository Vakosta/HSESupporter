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

        [Get("/dormitories/")]
        Task<List<Dormitory>> GetDormitories([Header("Authorization")] string authorization);

        [Get("/problems/")]
        Task<List<Problem>> GetProblems([Header("Authorization")] string authorization);

        [Get("/messages/")]
        Task<List<Message>> GetMessages([Header("Authorization")] string authorization);

        [Post("/problems/")]
        Task<List<Problem>> SaveProblem([Header("Authorization")] string authorization,
            [Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);
    }
}