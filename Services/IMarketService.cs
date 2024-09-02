using CRUD_exam.Models;

namespace CRUD_exam.Services;

public interface IMarketService
{
    List<Market> GetMarkets();
    Market GetMarketByName(string name);
    bool CreateMarket(Market market);
    bool UpdateMarket(Market market);
    bool DeleteMarket(int id);
    List<Market> GetMarketWithOwner();
}