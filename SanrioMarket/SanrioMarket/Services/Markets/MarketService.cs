namespace SanrioMarket.Services.Markets;
using SanrioMarket.Models;

public class MarketService : IMarketService{
    private static readonly Dictionary<Guid, Market> _markets = new();
    public void CreateMarket(Market market){
        _markets.Add(market.Id, market);
    }

    public Market GetMarket(Guid id){
        return _markets[id];
    }

    public void UpsertMarket(Market market){
        _markets[market.Id] = market;
    }

    public void DeleteMarket(Guid id){
        _markets.Remove(id);
    }
}