using Rest_API_final.Data;
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
            return _context.Clients.Any(c => c.DeviceToken == deviceToken);
        }

        public bool CreateClient(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
