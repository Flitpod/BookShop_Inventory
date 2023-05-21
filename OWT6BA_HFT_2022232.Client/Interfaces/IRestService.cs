using System.Collections.Generic;

namespace OWT6BA_HFT_2022232.Client.Interfaces
{
    public interface IRestService
    {
        void Delete(int id, string endpoint);
        T Get<T>(int id, string endpoint);
        List<T> Get<T>(string endpoint);
        T GetSingle<T>(string endpoint);
        void Post<T>(T item, string endpoint);
        void Put<T>(T item, string endpoint);
    }
}