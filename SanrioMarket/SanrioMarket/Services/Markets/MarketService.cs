namespace SanrioMarket.Services.Markets;

using ErrorOr;
using SanrioMarket.Models;
using SanrioMarket.ServiceErrors;

public class MarketService : IMarketService{
    private static readonly Dictionary<Guid, Market> _markets = new();
    public ErrorOr<Created> CreateMarket(Market market){
        _markets.Add(market.Id, market);

        return Result.Created;
    }

    public ErrorOr<Market> GetMarket(Guid id){
        if(_markets.TryGetValue(id, out var market)){
            return _markets[id];
        }

        return Errors.Market.NotFound;
    }

    public ErrorOr<UpsertedMarket> UpsertMarket(Market market){

        var isNewlyCreated = !_markets.ContainsKey(market.Id);
        _markets[market.Id] = market;

        return new UpsertedMarket(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteMarket(Guid id){
        _markets.Remove(id);

        return Result.Deleted;
    }
}