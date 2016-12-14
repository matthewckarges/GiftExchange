using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Data.TranferObjects.Models;

namespace GE.Data.Stores
{
    interface IDataStore : IDisposable
    {
        List<ExchangeListItem> GetExchangeListForUser(int userId);

        ExchangeDisplay GetExchangeDisplay(int exchangeId, int userId);

    }
}
