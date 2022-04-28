using SharesAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharesAPI.Models
{
    public interface ISharesRepository
    {
        IEnumerable<Shares> AllShares();

        Task CreateAsync(Shares shares);
        Shares GetShares(string name);
    }
}
