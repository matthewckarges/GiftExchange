using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Data.TranferObjects.Models;
using GE.Data.Utility;

namespace GE.Data.Stores
{
    interface IDataStore : IDisposable
    {
        IResponse<List<ExchangeListItem>> GetExchangeListForUser(int userId);

        IResponse<ExchangeDisplay> GetExchange(int exchangeId, int userId);

    }
}
