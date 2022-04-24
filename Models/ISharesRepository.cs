using SharesAPI;
using System.Collections.Generic;

namespace SharesAPI.Models
{
    public interface ISharesRepository
    {
        IEnumerable<Shares> AllShares { get; }

        //Shares GetShares(string name);
    }
}
