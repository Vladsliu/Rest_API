using Rest_API_final.Models;

namespace Rest_API_final.Interfaces
{
    public interface IClientRepository
    {
        bool ClientExist(string deviceToken);
        int CreateClient(Client client);
        string GetKeyByClient(Client client);
        bool Save();

    }
}
