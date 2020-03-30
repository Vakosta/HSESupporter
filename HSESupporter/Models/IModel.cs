using System.Collections.Generic;

namespace HSESupporter.Models
{
    public interface IModel
    {
        Dictionary<string, object> GetDictionaryParams();
    }
}