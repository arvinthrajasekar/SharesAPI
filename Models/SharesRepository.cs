using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharesAPI.Models
{
    public class SharesRepository : ISharesRepository
    {
        private readonly ShareDbContext _shareDbContext;



        public SharesRepository(ShareDbContext shareDbContext)

        {
            _shareDbContext = shareDbContext;
        }

        public IEnumerable<Shares> AllShares()
        {
            
                return _shareDbContext.Share.ToList();
            
        }

        public Task CreateAsync(Shares shares)
        {
            _shareDbContext.Add(shares);
            return _shareDbContext.SaveChangesAsync();
        }

        public Shares GetShares(string name)
        {
            var res = _shareDbContext.Share.FirstOrDefault(s => s.Name == name);
            
            return res;
        }
    }
}
