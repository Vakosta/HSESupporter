using System.Collections.Generic;
using System.Threading.Tasks;
using HSESupporter.Models;
using Refit;

namespace HSESupporter.Services
{
    [Headers("Authorization: Token")]
    public interface IHseSupporterApi
    {
        [Headers("Authorization")]
        [Post("/auth/register/")]
        Task<AuthResult> Login([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Headers("Authorization")]
        [Post("/auth/register/confirm-email/")]
        Task<AuthResult> LoginConfirm([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Get("/auth/accept-status/")]
        Task<AuthResult> CheckAcceptStatus();

        [Get("/main_page/")]
        Task<MainPage> GetMainPage();

        [Get("/profile/")]
        Task<Profile> GetProfile();

        [Post("/profile/")]
        Task<Profile> SetProfile([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Get("/dormitories/")]
        Task<List<Dormitory>> GetDormitories();

        [Get("/dormitories/{id}/")]
        Task<Dormitory> GetDormitory(int id);

        [Get("/problems/")]
        Task<List<Problem>> GetProblems();

        [Get("/notices/")]
        Task<List<Notice>> GetNotices();

        [Get("/messages/")]
        Task<List<Message>> GetMessages();

        [Post("/problems/")]
        Task<List<Problem>> SaveProblem([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);

        [Get("/problems/{id}/")]
        Task<Problem> GetProblem(int id);

        [Delete("/problems/{id}/")]
        Task<Problem> DeleteProblem(int id);

        [Post("/messages/")]
        Task<List<Problem>> SendMessage([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, object> data);
    }
}