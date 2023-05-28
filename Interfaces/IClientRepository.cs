﻿using Rest_API_final.Models;

namespace Rest_API_final.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        bool ClientExist(string deviceToken);
        bool CreateClient(Client client);
        bool Save();

    }
}
