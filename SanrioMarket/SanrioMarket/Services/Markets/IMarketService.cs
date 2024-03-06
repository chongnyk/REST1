using SanrioMarket.Contracts.Market;
using SanrioMarket.Models;

namespace SanrioMarket.Services.Markets;

public interface IMarketService{
    void CreateMarket(Market market);
    void DeleteMarket(Guid id);
    Market GetMarket(Guid id);
    void UpsertMarket(Market market);
}