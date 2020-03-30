using System.Collections.Generic;
using System.Threading.Tasks;
using HSESupporter.Models;
using Refit;

namespace HSESupporter.Services
{
    [Headers("Authorization: Token")]
    public interface IHseSupporterApi
    {
        [Post("/api/auth/token/login")]
        Task<AuthResult> Login([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Get("/dormitories/")]
        Task<List<Dormitory>> GetDormitories();

        [Get("/problems/")]
        Task<List<Problem>> GetProblems();

        [Get("/messages/")]
        Task<List<Message>> GetMessages();

        [Post("/problems/")]
        Task<List<Problem>> SaveProblem([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Delete("/problems/{id}/")]
        Task<Problem> DeleteProblem(int id);
    }
}