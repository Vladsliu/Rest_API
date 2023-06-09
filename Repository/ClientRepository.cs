﻿using Rest_API_final.Data;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;

namespace Rest_API_final.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public bool ClientExist(string deviceToken)
        {
            var a = _context.Clients.Any(c => c.DeviceToken == deviceToken);
            return a;
        }

        public int CreateClient(Client client)
        {
            _context.Add(client);
            Save();
            return client.Id;
        }

        public string GetKeyByClient(Client client)
        {
            return _context.Experiments.Where(e => e.ClientId == client.Id).Select(c => c.OptionValue).ToString();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
